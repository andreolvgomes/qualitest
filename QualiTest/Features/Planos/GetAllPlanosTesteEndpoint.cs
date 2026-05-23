using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Planos
{
    [HttpGet("planos")]
    public class GetAllPlanosTesteEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<PlanosEntity> _repository;

        public GetAllPlanosTesteEndpoint(IRepositoryBase<PlanosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await Send.OkAsync(await _repository.GetAll());
        }
    }
}