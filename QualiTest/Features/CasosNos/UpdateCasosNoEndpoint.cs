using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.CasosNos
{
    [HttpPut("casosnos/{id:Guid}")]
    public class UpdateCasosNoEndpoint : Endpoint<CasosNosEntity>
    {
        private readonly ICasosNosRepository _repository;

        public UpdateCasosNoEndpoint(ICasosNosRepository repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CasosNosEntity req, CancellationToken ct)
        {
            await _repository.Update(req);
            await Send.OkAsync();
        }
    }
}