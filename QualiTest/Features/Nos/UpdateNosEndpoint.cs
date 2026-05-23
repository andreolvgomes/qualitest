using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpPut("nos/{id:Guid}")]
    public class UpdateNosEndpoint : Endpoint<NosEntity>
    {
        private readonly IRepositoryBase<NosEntity> _repository;

        public UpdateNosEndpoint(IRepositoryBase<NosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(NosEntity req, CancellationToken ct)
        {
            await _repository.Update(req);
            await Send.OkAsync();
        }
    }
}