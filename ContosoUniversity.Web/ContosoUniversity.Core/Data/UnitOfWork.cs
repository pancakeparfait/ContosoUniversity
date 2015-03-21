using System;
using System.Data.Entity;
using System.Linq;

namespace ContosoUniversity.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        #region [Properties]

        private readonly SchoolContext _context;

        #endregion

        #region [Ctors]

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
        }

        #endregion

        public T Get<T>(object id) where T : class
        {
            return TryDbAction(() => _context.Set<T>().Find(id));
        }

        public IQueryable<T> All<T>() where T : class
        {
            return TryDbAction(() => _context.Set<T>());
        }

        public T Add<T>(T entity) where T : class
        {
            return TryDbAction(() => _context.Set<T>().Add(entity));
        }

        public T Update<T>(T entity) where T : class
        {
            return TryDbAction(() =>
            {
                var obj = _context.Set<T>().Attach(entity);
                _context.Entry(obj).State = EntityState.Modified;
                return obj;
            });
        }

        public void Delete<T>(T entity) where T : class
        {
            TryDbAction(() => _context.Set<T>().Remove(entity));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #region [Helpers]

        private T TryDbAction<T>(Func<T> action)
        {
            try
            {
                return action.Invoke();
            }
            catch (Exception ex)
            {
                // Log
                throw;
            }
        }

        #endregion
    }
}