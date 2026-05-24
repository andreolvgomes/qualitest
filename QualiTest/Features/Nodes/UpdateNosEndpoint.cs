using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpPut("nodes/{id:Guid}")]
    public class UpdateNosEndpoint : Endpoint<NodesEntity>
    {
        private readonly IRepositoryBase<NodesEntity> _repository;

        public UpdateNosEndpoint(IRepositoryBase<NodesEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(NodesEntity req, CancellationToken ct)
        {
            await _repository.Update(req);
            await Send.OkAsync();
        }
    }
}