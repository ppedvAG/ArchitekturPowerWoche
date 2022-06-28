using HalloEfCore.Contracts;
using HalloEfCore.Model;

namespace HalloEfCore.Tests.Logic
{
    class TestRepoStub : IRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            if (typeof(T) == typeof(Mitarbeiter))
            {
                var m1 = new Mitarbeiter() { GebDatum = DateTime.Now.AddYears(-10) };
                var m2 = new Mitarbeiter() { GebDatum = DateTime.Now.AddYears(-6) };
                return new[] { m1, m2 }.Cast<T>().AsQueryable();
            }

            throw new NotImplementedException();
        }

        public int SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
