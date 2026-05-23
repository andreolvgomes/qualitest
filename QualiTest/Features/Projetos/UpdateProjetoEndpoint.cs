using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpPut("projetos/{id:Guid}")]
    public class UpdateProjetoEndpoint : Endpoint<ProjetosEntity>
    {
        private readonly IProjetosRepository _projetosRepository;

        public UpdateProjetoEndpoint(IProjetosRepository projetosRepository)
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