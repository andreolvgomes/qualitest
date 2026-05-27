using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    [HttpPut("casos/{id:Guid}")]
    public class UpdateCasosEndpoint : Endpoint<CasosEntity>
    {
        private readonly ICasosRepository _casosRepository;

        public UpdateCasosEndpoint(ICasosRepository casosRepository)
        {
            _casosRepository = casosRepository;
        }

        public async override Task HandleAsync(CasosEntity req, CancellationToken ct)
        {
            await _casosRepository.Update(req);
            await Send.OkAsync();
        }
    }
}