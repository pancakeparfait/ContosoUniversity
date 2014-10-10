using System;
using ContosoUniversity.Core.Data;

namespace ContosoUniversity.Core.Lib.Services.Impl
{
    public class EntityServiceBase : IEntityService
    {
        #region [Properties]

        protected IUnitOfWork UnitOfWork;

        #endregion

        #region [Ctors]

        public EntityServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion

        public T GetById<T>(object id)
            where T : class
        {
            return UnitOfWork.Get<T>(id);
        }

        protected T InsertOrUpdate<T>(object id, Action<T> setProperties)
            where T : class, new()
        {
            var isNew = (id == null);

            var entity = isNew ? new T() : UnitOfWork.Get<T>(id);

            setProperties.Invoke(entity);

            return isNew ? UnitOfWork.Add(entity) : UnitOfWork.Update(entity);
        }

        public void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}
