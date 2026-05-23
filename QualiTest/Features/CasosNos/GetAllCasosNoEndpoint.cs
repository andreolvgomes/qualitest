using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.CasosNos
{
    [HttpGet("casosnos")]
    public class GetAllCasosNoEndpoint : Endpoint<CasosNosEntity>
    {
        private readonly ICasosNosRepository _repository;

        public GetAllCasosNoEndpoint(ICasosNosRepository repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CasosNosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.GetAll());
        }
    }
}