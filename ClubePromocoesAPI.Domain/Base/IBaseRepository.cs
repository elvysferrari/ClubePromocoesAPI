using System.Linq.Expressions;

namespace ClubePromocoesAPI.Domain.Base
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(int id);
        IEnumerable<TEntity> GetAll(bool asNoTracking = true);
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicado, bool asNoTracking = true);
        void Update(TEntity obj);
        void Remove(int id);
        void Remove(TEntity entity);
        Task<int> SaveChanges();
    }
}
