using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Suites
{
    [HttpPut("suites/{id:Guid}")]
    public class UpdateSuitesEndpoint : Endpoint<SuitesEntity>
    {
        private readonly IRepositoryBase<SuitesEntity> _repository;

        public UpdateSuitesEndpoint(IRepositoryBase<SuitesEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(SuitesEntity req, CancellationToken ct)
        {
            await _repository.Update(req);
            await Send.OkAsync();
        }
    }
}
