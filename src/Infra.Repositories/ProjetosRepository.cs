using System.Data;

namespace Infra.Repositories
{
    public interface IProjetosRepository : IRepositoryBase<ProjetosEntity>
    {
    }

    public class ProjetosRepository : RepositoryBase<ProjetosEntity>,
        IProjetosRepository
    {
        public ProjetosRepository(IDbConnection connection)
            : base(connection)
        {
        }
    }
}