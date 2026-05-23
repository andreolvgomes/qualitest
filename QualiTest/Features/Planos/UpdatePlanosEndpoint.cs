using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Planos
{
    [HttpPut("planos/{id:Guid}")]
    public class UpdatePlanosEndpoint : Endpoint<PlanosEntity>
    {
        private readonly IRepositoryBase<PlanosEntity> _repository;

        public UpdatePlanosEndpoint(IRepositoryBase<PlanosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PlanosEntity req, CancellationToken ct)
        {
            await _repository.Update(req);
            await Send.OkAsync();
        }
    }
}