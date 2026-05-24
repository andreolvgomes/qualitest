using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    [HttpGet("casos/{caso_id:Guid}/passos")]
    public class GetAllPassosEndpoint : Endpoint<PassosEntity>
    {
        private readonly IRepositoryBase<PassosEntity> _repository;

        public GetAllPassosEndpoint(IRepositoryBase<PassosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PassosEntity req, CancellationToken ct)
        {
            var caso_id = Route<Guid>("caso_id");
            await Send.OkAsync(await _repository.GetAll(new { caso_id }));
        }
    }
}