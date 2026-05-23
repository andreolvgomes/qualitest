using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpGet("nos/{id:Guid}")]
    public class GetNosEndpoint : Endpoint<NosEntity>
    {
        private readonly IRepositoryBase<NosEntity> _repository;

        public GetNosEndpoint(IRepositoryBase<NosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(NosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.Get(Route<Guid>("id")));
        }
    }
}