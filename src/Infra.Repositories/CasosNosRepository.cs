using System.Data;

namespace Infra.Repositories
{
    public interface ICasosNosRepository : IRepositoryBase<CasosNosEntity>
    {

    }
    public class CasosNosRepository : RepositoryBase<CasosNosEntity>, ICasosNosRepository
    {
        public CasosNosRepository(IDbConnection connection)
            : base(connection)
        {
        }
    }
}