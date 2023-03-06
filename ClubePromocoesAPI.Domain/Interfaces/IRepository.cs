using System.Linq.Expressions;

namespace ClubePromocoesAPI.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Adicionar(TEntity obj);
        Task<TEntity> ObterPorId(long id);
        IQueryable<TEntity> ObterTodos(bool asNoTracking = true);        
        IQueryable<TEntity> ObterPor(Expression<Func<TEntity, bool>> predicado, bool asNoTracking = true);
        Task Atualizar(TEntity obj);
        Task Remover(long id);
        Task Remover(TEntity entity);
        Task<int> SaveChanges();
    }
}
