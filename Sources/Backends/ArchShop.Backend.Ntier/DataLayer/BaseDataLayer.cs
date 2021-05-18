
using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ArchShop.DataLayer
{
    public abstract class BaseDataLayer<TEntity> where TEntity : class
    {
        protected readonly ArchShopContext _context;

        protected DbSet<TEntity> Entities => _context.Set<TEntity>();

        protected BaseDataLayer(ArchShopContext dataContext)
        {
            _context = dataContext;
        }

        public TEntity Add(TEntity entity)
        {
            Entities.Add(entity);
            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            Entities.Remove(entity);
            return entity;
        }
    }
}
