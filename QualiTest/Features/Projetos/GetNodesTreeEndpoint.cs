using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpGet("projetos/{projeto_id:Guid}/tree")]
    public class GetNodesTreeEndpoint : Endpoint<NodesEntity>
    {
        private readonly INodesRepository _repository;

        public GetNodesTreeEndpoint(INodesRepository repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(NodesEntity req, CancellationToken ct)
        {
            Guid? value = null;
            if (HttpContext.Request.Query.TryGetValue("node_id", out var values))
            {
                Guid.TryParse(values.FirstOrDefault(), out var pageNumber);
                value = pageNumber;
            }

            await Send.OkAsync(await _repository.GetArvore(Route<Guid>("projeto_id"), node_id: value));
        }
    }
}