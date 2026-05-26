using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    [HttpDelete("casos/{id:Guid}")]
    public class DeleteCasosEndpoint : Endpoint<CasosEntity>
    {
        private readonly ICasosRepository _casosRepository;
        private readonly INodesRepository _nodesRepository;

        public DeleteCasosEndpoint(ICasosRepository casosRepository,
            INodesRepository nodesRepository)
        {
            _casosRepository = casosRepository;
            _nodesRepository = nodesRepository;
        }

        public async override Task HandleAsync(CasosEntity req, CancellationToken ct)
        {
            var entity = await _casosRepository.Get(Route<Guid>("id"));
            await _nodesRepository.Delete(entity.Node_id);

            await Send.OkAsync();
        }
    }
}