using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpPost("nos")]
    public class CriarNosEndpoint : Endpoint<NosEntity>
    {
        private readonly IRepositoryBase<NosEntity> _repository;

        public CriarNosEndpoint(IRepositoryBase<NosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(NosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.Create(req));
        }
    }
}