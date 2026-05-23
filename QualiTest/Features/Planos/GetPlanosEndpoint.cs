using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Planos
{
    [HttpGet("planos/{id:Guid}")]
    public class GetPlanosEndpoint : Endpoint<PlanosEntity>
    {
        private readonly IRepositoryBase<PlanosEntity> _repository;

        public GetPlanosEndpoint(IRepositoryBase<PlanosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PlanosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.Get(Route<Guid>("id")));
        }
    }
}