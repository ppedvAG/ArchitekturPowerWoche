using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using HalloEfCore.Data;
using HalloEfCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

            //Assert.IsTrue(result);
            result.Should().BeTrue();
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
                //Assert.AreEqual(2, result);
                result.Should().Be(2);
            }

            //READ + UPDATE
            using (var con = new EfContext(ConString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                //Assert.AreEqual(m.Name, loaded.Name);
                loaded.Name.Should().Be(m.Name);

                loaded.Name = newName;
                var result = con.SaveChanges();
                //Assert.AreEqual(1, result);
                result.Should().Be(1);
            }

            //check UPDATE + DELETE
            using (var con = new EfContext(ConString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                Assert.AreEqual(newName, loaded.Name);
                loaded.Name.Should().Be(newName);

                con.Remove(loaded);
                var result = con.SaveChanges();
                //Assert.AreEqual(2, result);
                result.Should().Be(2);
            }

            //check DELETE
            using (var con = new EfContext(ConString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                //Assert.IsNull(loaded);
                loaded.Should().BeNull();
            }

        }

        [TestMethod]
        public void Can_create_read_Mitarbeiter_AutoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter("Id"));
            var m = fix.Create<Mitarbeiter>();

            using (var con = new EfContext(ConString))
            {
                con.Add(m);
                con.SaveChanges();
            }

            using (var con = new EfContext(ConString))
            {
                var loaded = con.Mitarbeiter.Include(x => x.Kunden).Include(x => x.Abteilungen).First(x => x.Id == m.Id);
                loaded.Should().BeEquivalentTo(m, x => x.IgnoringCyclicReferences());
            }

        }


        internal class PropertyNameOmitter : ISpecimenBuilder
        {
            private readonly IEnumerable<string> names;

            internal PropertyNameOmitter(params string[] names)
            {
                this.names = names;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo != null && names.Contains(propInfo.Name))
                    return new OmitSpecimen();

                return new NoSpecimen();
            }
        }

    }
}
