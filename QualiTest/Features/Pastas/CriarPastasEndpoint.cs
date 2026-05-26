using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpPost("pastas")]
    public class CriarPastasEndpoint : Endpoint<NodesEntity>
    {
        private readonly IRepositoryBase<NodesEntity> _repository;

        public CriarPastasEndpoint(IRepositoryBase<NodesEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(NodesEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.Create(req));
        }
    }
}