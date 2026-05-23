using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    [HttpPut("casos/{id:Guid}")]
    public class UpdateCasosEndpoint : Endpoint<CasosEntity>
    {
        private readonly IRepositoryBase<CasosEntity> _repository;

        public UpdateCasosEndpoint(IRepositoryBase<CasosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CasosEntity req, CancellationToken ct)
        {
            await _repository.Update(req);
            await Send.OkAsync();
        }
    }
}