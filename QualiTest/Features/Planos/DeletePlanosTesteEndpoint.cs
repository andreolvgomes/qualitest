using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Planos
{
    [HttpDelete("planos/{id:Guid}")]
    public class DeletePlanosTesteEndpoint : Endpoint<PlanosEntity>
    {
        private readonly IRepositoryBase<PlanosEntity> _repository;

        public DeletePlanosTesteEndpoint(IRepositoryBase<PlanosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PlanosEntity req, CancellationToken ct)
        {
            await _repository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}