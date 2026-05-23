using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.CasosNos
{
    [HttpDelete("casosnos/{id:Guid}")]
    public class DeleteCasosNoEndpoint : Endpoint<CasosNosEntity>
    {
        private readonly ICasosNosRepository _repository;

        public DeleteCasosNoEndpoint(ICasosNosRepository repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CasosNosEntity req, CancellationToken ct)
        {
            await _repository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}