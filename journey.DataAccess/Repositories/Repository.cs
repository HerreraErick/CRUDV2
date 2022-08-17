using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace journey.DataAccess.Repositories
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class, new()
    {
        private readonly JourneyContext _context;

        protected JourneyContext Context { get => _context; }

        public Repository(JourneyContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
            }
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                var mensaje = "Error message: " + ex.Message;
                //throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
                if (ex.InnerException != null)
                {
                    mensaje = mensaje + "Inner exception: " + ex.InnerException.Message;
                }
                mensaje = mensaje + " Stack trace: " + ex.StackTrace;

                throw new Exception($"{nameof(entity)} could not be saved: {mensaje}");
            }
        }

        public virtual async Task DeleteAsync(TId id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            _context.Remove<TEntity>(entity);
            await _context.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public virtual async Task<TEntity> GetAsync(TId id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.InnerException}");
            }
        }
    }
}
