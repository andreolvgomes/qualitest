using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Nos
{
    [HttpDelete("nos/{id:Guid}")]
    public class DeleteNosEndpoint : Endpoint<NosEntity>
    {
        private readonly IRepositoryBase<NosEntity> _repository;

        public DeleteNosEndpoint(IRepositoryBase<NosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(NosEntity req, CancellationToken ct)
        {
            await _repository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}