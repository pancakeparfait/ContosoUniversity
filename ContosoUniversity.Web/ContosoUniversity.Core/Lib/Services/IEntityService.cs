namespace ContosoUniversity.Core.Lib.Services
{
    public interface IEntityService
    {
        T GetById<T>(object id)
            where T : class;

        void SaveChanges();
    }
}