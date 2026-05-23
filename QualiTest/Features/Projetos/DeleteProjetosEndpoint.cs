using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpDelete("projetos/{id:Guid}")]
    public class DeleteProjetosEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<ProjetosEntity> _projetosRepository;

        public DeleteProjetosEndpoint(IRepositoryBase<ProjetosEntity> projetosRepository)
        {
            _projetosRepository = projetosRepository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await _projetosRepository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}