using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Suites
{
    [HttpDelete("suites/{id:Guid}")]
    public class DeleteSuitesEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<SuitesEntity> _repository;
        private readonly INodesRepository _nodesRepository;

        public DeleteSuitesEndpoint(IRepositoryBase<SuitesEntity> repository,
            INodesRepository nodesRepository)
        {
            _repository = repository;
            _nodesRepository = nodesRepository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            var entity = await _repository.Get(Route<Guid>("id"));
            await _nodesRepository.Delete(entity.Node_id);

            await Send.OkAsync();
        }
    }
}
