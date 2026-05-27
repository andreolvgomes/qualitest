using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos.Passos
{
    [HttpPut("casos/{caso_id:Guid}/passos/{id:Guid}")]
    public class UpdatePassosEndpoint : Endpoint<PassosEntity>
    {
        private readonly IRepositoryBase<PassosEntity> _repository;

        public UpdatePassosEndpoint(IRepositoryBase<PassosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PassosEntity req, CancellationToken ct)
        {
            await _repository.Update(req);
            await Send.OkAsync();
        }
    }
}