using HalloEfCore.Contracts;
using System;
using System.Linq;

namespace HalloEfCore.Data
{
    internal class EfRepository : IRepository
    {
        EfContext con = new EfContext();

        public void Add<T>(T entity) where T : class
        {
            con.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            con.Remove(entity);
        }

        public T GetById<T>(int id) where T : class
        {
            return con.Find<T>(id);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return con.Set<T>();
        }

        public int SaveAll()
        {
            return con.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            con.Update<T>(entity);
        }
    }
}
