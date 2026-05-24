using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpDelete("nos/{id:Guid}")]
    public class DeleteNosEndpoint : Endpoint<NodesEntity>
    {
        private readonly IRepositoryBase<NodesEntity> _repository;

        public DeleteNosEndpoint(IRepositoryBase<NodesEntity> repository)
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