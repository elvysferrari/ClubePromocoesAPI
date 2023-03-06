using ClubePromocoesAPI.Domain.Base;
using ClubePromocoesAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Data.Repository.Base
{
    public abstract class Repository<TEntity> : Repository<IDBContext, TEntity> where TEntity : class
    {
        protected Repository(IDBContext context) : base(context)
        {
        }
    }
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TEntity : class
        where TContext : IDBContext
    {
        protected virtual TContext Db { get; private set; }
        protected readonly DbSet<TEntity> DbSet;
        protected Repository(TContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity entity)
            => await Db
                .Set<TEntity>()
                .AddAsync(entity);

        public async Task Atualizar(TEntity entity)
        {            
            await Task.FromResult(Db
                .Set<TEntity>()
                .Update(entity));
        }

        public virtual async Task<TEntity> ObterPorId(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Remover(long id)
        {
            TEntity entity = DbSet.FindAsync(id).Result;
            
            await Task.FromResult(Db
                .Set<TEntity>()
                .Remove(entity));
        }

        public async Task Remover(TEntity entity)
        {            
            await Task.FromResult(Db
                .Set<TEntity>()
                .Remove(entity));
        }

        public async Task<int> SaveChanges()
            => await Db.SaveChangesAsync();

        public void Dispose()
            => Db.Dispose();

        public IQueryable<TEntity> ObterTodos(bool asNoTracking = true)
        {
            if (!asNoTracking)
                return DbSet;

            return DbSet.AsNoTracking();
        }

        public IQueryable<TEntity> ObterPor(Expression<Func<TEntity, bool>> predicado, bool asNoTracking = true)
        {
            if (!asNoTracking)
                return DbSet.Where(predicado);

            return DbSet.Where(predicado).AsNoTracking();
        }

    }
    
}
