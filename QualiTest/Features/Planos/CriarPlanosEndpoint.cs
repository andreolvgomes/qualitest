using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Planos
{
    [HttpPost("planos")]
    public class CriarPlanosEndpoint : Endpoint<PlanosEntity>
    {
        private readonly IRepositoryBase<PlanosEntity> _repository;

        public CriarPlanosEndpoint(IRepositoryBase<PlanosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PlanosEntity req, CancellationToken ct)
        {
            var entity = await _repository.Create(req);
            await Send.OkAsync(req, ct);
        }
    }
}