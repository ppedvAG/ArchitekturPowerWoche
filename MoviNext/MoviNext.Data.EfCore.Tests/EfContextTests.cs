using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviNext.Model;

namespace MoviNext.Data.EfCore.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void Can_create_DB()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow(SpannungsEinheit.mV)]
        [DataRow(SpannungsEinheit.V)]
        [DataRow(SpannungsEinheit.MV)]
        public void Can_store_SpannungsEinheit(SpannungsEinheit se)
        {
            var ur = new Umrichter() { SpannungsEinheit = se, Steuerung = new Steuerung() };
            using (var con = new EfContext())
            {
                con.Add(ur);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                con.Umrichter?.Find(ur.Id)?.SpannungsEinheit.Should().Be(se);
            }
        }

        [TestMethod]
        [DataRow(FrequenzEinheit.Hz)]
        [DataRow(FrequenzEinheit.MHz)]
        [DataRow(FrequenzEinheit.GHz)]
        public void Can_store_FrequenzEinheit(FrequenzEinheit fe)
        {
            var ur = new Umrichter() { FrequenzEinheit = fe, Steuerung = new Steuerung() };
            using (var con = new EfContext())
            {
                con.Add(ur);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                con.Umrichter?.Find(ur.Id)?.FrequenzEinheit.Should().Be(fe);
            }
        }

        [TestMethod]
        [DataRow(LeistungsEinheit.mW)]
        [DataRow(LeistungsEinheit.W)]
        [DataRow(LeistungsEinheit.MW)]
        public void Can_store_LeistungsEinheit(LeistungsEinheit le)
        {
            var ur = new Umrichter() { LeistungsEinheit = le, Steuerung = new Steuerung() };
            using (var con = new EfContext())
            {
                con.Add(ur);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                con.Umrichter?.Find(ur.Id)?.LeistungsEinheit.Should().Be(le);
            }
        }


        [TestMethod]
        public void EfConext_can_AutoFixture_create_Umrichter()
        {
            var fix = new Fixture();
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            var ur = fix.Create<Umrichter>();

            using (var con = new EfContext())
            {
                con.Add(ur);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                con.Umrichter?.Find(ur.Id)?.Should().BeEquivalentTo(ur, x => x.IgnoringCyclicReferences());
            }
        }

        [TestMethod]
        public void EfContext_delete_Umrichter_should_delete_all_Subkomponenten()
        {
            var ur = new Umrichter() { Steuerung = new Steuerung() };
            var sk1 = new Subkomponente() { };
            var sk2 = new Subkomponente() { };
            ur.Subkomponenten.Add(sk1);
            ur.Subkomponenten.Add(sk2);

            using (var con = new EfContext())
            {
                con.Add(ur);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Find<Umrichter>(ur.Id);
                loaded.Subkomponenten.Count.Should().Be(2);
                con.Find<Subkomponente>(sk1.Id).Should().NotBeNull();
                con.Find<Subkomponente>(sk2.Id).Should().NotBeNull();

                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                con.Find<Umrichter>(ur.Id).Should().BeNull();
                con.Find<Subkomponente>(sk1.Id).Should().BeNull();
                con.Find<Subkomponente>(sk2.Id).Should().BeNull();
            }
        }


    }
}