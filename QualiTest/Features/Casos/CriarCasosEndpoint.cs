using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    [HttpPost("casos")]
    public class CriarCasosEndpoint : Endpoint<CasosEntity>
    {
        private readonly IRepositoryBase<CasosEntity> _repository;

        public CriarCasosEndpoint(IRepositoryBase<CasosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CasosEntity req, CancellationToken ct)
        {
            var entity = await _repository.Create(req);
            await Send.OkAsync(req, ct);
        }
    }
}