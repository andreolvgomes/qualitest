using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.CasosNos
{
    [HttpPost("casosnos")]
    public class CriarCasosNoEndpoint : Endpoint<CasosNosEntity>
    {
        private readonly ICasosNosRepository _repository;

        public CriarCasosNoEndpoint(ICasosNosRepository repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CasosNosEntity req, CancellationToken ct)
        {
            await _repository.Create(req);
            await Send.OkAsync();
        }
    }
}