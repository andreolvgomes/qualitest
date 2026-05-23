using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpGet("nos")]
    public class GetAllNosEndpoint : Endpoint<NosEntity>
    {
        private readonly IRepositoryBase<NosEntity> _repository;

        public GetAllNosEndpoint(IRepositoryBase<NosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(NosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.GetAll());
        }
    }
}