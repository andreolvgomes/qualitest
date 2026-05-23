using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpPut("projetos/{id:Guid}")]
    public class UpdateProjetosEndpoint : Endpoint<ProjetosEntity>
    {
        private readonly IRepositoryBase<ProjetosEntity> _projetosRepository;

        public UpdateProjetosEndpoint(IRepositoryBase<ProjetosEntity> projetosRepository)
        {
            _projetosRepository = projetosRepository;
        }

        public async override Task HandleAsync(ProjetosEntity req, CancellationToken ct)
        {
            await _projetosRepository.Update(req);
            await Send.OkAsync();
        }
    }
}