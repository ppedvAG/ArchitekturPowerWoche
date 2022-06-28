using System.Linq;

namespace HalloEfCore.Contracts
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : class;
        T GetById<T>(int id) where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        int SaveAll();
    }
}
