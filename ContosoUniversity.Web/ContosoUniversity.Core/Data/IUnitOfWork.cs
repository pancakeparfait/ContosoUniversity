using System.Linq;

namespace ContosoUniversity.Core.Data
{
    public interface IUnitOfWork
    {
        T Get<T>(object id) where T : class;

        IQueryable<T> All<T>() where T : class;

        T Add<T>(T entity) where T : class;

        T Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void SaveChanges();
    }
}
