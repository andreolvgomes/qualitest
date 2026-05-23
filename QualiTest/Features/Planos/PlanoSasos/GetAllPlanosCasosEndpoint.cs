using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Planos
{
    [HttpGet("planos/{planos_id:Guid}/planoscasos")]
    public class GetAllPlanosCasosEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<PlanoCasosEntity> _repository;

        public GetAllPlanosCasosEndpoint(IRepositoryBase<PlanoCasosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            var planos_id = Route<Guid>("planos_id");
            await Send.OkAsync(await _repository.GetAll(new { planos_id }));
        }
    }
}