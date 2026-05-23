using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Planos
{
    [HttpGet("planos/{plano_id:Guid}/planoscasos")]
    public class GetAllPlanosCasosEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<PlanoCasosEntity> _repository;

        public GetAllPlanosCasosEndpoint(IRepositoryBase<PlanoCasosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            var plano_id = Route<Guid>("plano_id");
            await Send.OkAsync(await _repository.GetAll(new { plano_id }));
        }
    }
}