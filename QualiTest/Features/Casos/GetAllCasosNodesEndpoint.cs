using FastEndpoints;
using Infra.Repositories;
using Namotion.Reflection;

namespace QualiTest.Features.Casos
{
    [HttpGet("casos/{projeto_id:Guid}/list")]
    public class GetAllCasosNodesEndpoint : EndpointWithoutRequest
    {
        private readonly ICasosRepository _casosRepository;

        public GetAllCasosNodesEndpoint(ICasosRepository casosRepository)
        {
            _casosRepository = casosRepository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            Guid? value = null;
            if (HttpContext.Request.Query.TryGetValue("node_id", out var values))    
            {
                Guid.TryParse(values.FirstOrDefault(), out var pageNumber);
                value = pageNumber;
            }


            var response = await _casosRepository.Casos(Route<Guid>("projeto_id"), node_id: value);
            await Send.OkAsync(response);
        }
    }
}