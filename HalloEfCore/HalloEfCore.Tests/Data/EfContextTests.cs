using HalloEfCore.Data;
using HalloEfCore.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace HalloEfCore.Tests.Data
{
    [TestClass]
    public class EfContextTests
    {
        private const string ConString = "Server=(localdb)\\mssqllocaldb;Database=HalloEfCore_TEST;Trusted_Connection=true";

        [TestMethod]
        public void Can_create_DB()
        {
            var con = new EfContext(ConString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Can_create_read_update_delete_Mitarbeiter()
        {
            var m = new Mitarbeiter() { Name = $"Wilma_{Guid.NewGuid()}", Beruf = "Tester" };
            var newName = $"Betty_{Guid.NewGuid}";

            //CREATE
            using (var con = new EfContext(ConString))
            {
                con.Mitarbeiter.Add(m);
                var result = con.SaveChanges();
                Assert.AreEqual(2, result);
            }

            //READ + UPDATE
            using (var con = new EfContext(ConString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                Assert.AreEqual(m.Name, loaded.Name);

                loaded.Name = newName;
                var result = con.SaveChanges();
                Assert.AreEqual(1, result);
            }

            //check UPDATE + DELETE
            using (var con = new EfContext(ConString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                Assert.AreEqual(newName, loaded.Name);

                con.Remove(loaded);
                var result = con.SaveChanges();
                Assert.AreEqual(2, result);
            }

            //check DELETE
            using (var con = new EfContext(ConString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                Assert.IsNull(loaded);
            }

        }

    }
}
