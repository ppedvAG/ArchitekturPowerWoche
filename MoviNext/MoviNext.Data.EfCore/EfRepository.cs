using MoviNext.Model;
using MoviNext.Model.Contracts;

namespace MoviNext.Data.EfCore
{
    public class EfRepository : IRepository
    {
        EfContext con = new();

        public void Add<T>(T entity) where T : Entity
        {
            con.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            con.Remove(entity);
        }

        public T GetById<T>(int id) where T : Entity
        {
            return con.Find<T>(id);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return con.Set<T>();
        }

        public int SaveChanges()
        {
            return con.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            con.Update(entity);
        }
    }
}
