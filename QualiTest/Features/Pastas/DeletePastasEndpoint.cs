using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpDelete("pastas/{id:Guid}")]
    public class DeletePastasEndpoint : Endpoint<NodesEntity>
    {
        private readonly IRepositoryBase<NodesEntity> _repository;

        public DeletePastasEndpoint(IRepositoryBase<NodesEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(NodesEntity req, CancellationToken ct)
        {
            await _repository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}