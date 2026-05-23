using Dapper;
using DapperExtensions;
using System.Data;

namespace Infra.Repositories
{
    public abstract class EntityBase
    {
        [ExplicitKey]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? Created_At { get; set; } = DateTime.UtcNow;
    }

    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(Guid id);
        Task<IEnumerable<TEntity>> GetAll(object param = null);
        Task<TEntity> Get(Guid id);
    }

    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly IDbConnection _connection;

        public RepositoryBase(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<TEntity> Create(TEntity dto)
        {
            await _connection.InsertAsync(dto);
            return dto;
        }

        public async Task Delete(TEntity dto)
        {
            await _connection.DeleteAsync(dto);
        }

        public async Task Delete(Guid id)
        {
            var tableName = SqlMapperExtensions.GetTableName(typeof(TEntity));
            await _connection.ExecuteAsync($"delete from {tableName} where id = @id", new { id });
        }

        public async Task<IEnumerable<TEntity>> GetAll(object param = null)
        {
            return await _connection.GetAllAsync<TEntity>(param: param);
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await _connection.FindAsync<TEntity>(new { id = id });
        }

        public async Task Update(TEntity dto)
        {
            await _connection.UpdateAsync(dto);
        }
    }
}