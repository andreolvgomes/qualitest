using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.CasosNos
{
    [HttpGet("casosnos/{id:Guid}")]
    public class GetCasosNoEndpoint : Endpoint<CasosNosEntity>
    {
        private readonly ICasosNosRepository _repository;

        public GetCasosNoEndpoint(ICasosNosRepository repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CasosNosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.GetById(Route<Guid>("id")));
        }
    }
}