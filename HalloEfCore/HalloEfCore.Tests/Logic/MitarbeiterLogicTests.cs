using FakeItEasy;
using FluentAssertions;
using HalloEfCore.Contracts;
using HalloEfCore.Logic;
using HalloEfCore.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HalloEfCore.Tests.Logic
{

    [TestClass]
    public class MitarbeiterLogicTests
    {

        [TestMethod]
        public void GetAverageAgeOfAllMyMitarbeiter_2_Mitarbeiters_should_return_8_MOQ()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Mitarbeiter>()).Returns(() =>
            {
                var m1 = new Mitarbeiter() { GebDatum = DateTime.Now.AddYears(-10) };
                var m2 = new Mitarbeiter() { GebDatum = DateTime.Now.AddYears(-6) };
                return new[] { m1, m2 }.AsQueryable();
            });

            var result = MitarbeiterLogic.GetAverageAgeOfAllMyMitarbeiter(mock.Object);

            result.Should().Be(8);
        }

        [TestMethod]
        public void GetAverageAgeOfAllMyMitarbeiter_2_Mitarbeiters_should_return_8_FakeIt()
        {
            var fake = A.Fake<IRepository>();
            A.CallTo(() => fake.Query<Mitarbeiter>()).ReturnsLazily(() =>
            {
                var m1 = new Mitarbeiter() { GebDatum = DateTime.Now.AddYears(-10) };
                var m2 = new Mitarbeiter() { GebDatum = DateTime.Now.AddYears(-6) };
                return new[] { m1, m2 }.AsQueryable();
            });

            var result = MitarbeiterLogic.GetAverageAgeOfAllMyMitarbeiter(fake);

            result.Should().Be(8);
        }

        [TestMethod]
        public void GetAverageAgeOfAllMyMitarbeiter_2_Mitarbeiters_should_return_8_stub()
        {
            var result = MitarbeiterLogic.GetAverageAgeOfAllMyMitarbeiter(new TestRepoStub());
            result.Should().Be(8);
        }

        [TestMethod]
        public void GetAverageAgeOfAllMyMitarbeiter_no_Mitarbeiters_should_return_0()
        {
            var fake = A.Fake<IRepository>();
            A.CallTo(() => fake.Query<Mitarbeiter>()).ReturnsLazily(() =>
            {
                return new List<Mitarbeiter>().AsQueryable();
            });

            var act = () => MitarbeiterLogic.GetAverageAgeOfAllMyMitarbeiter(fake);

            act.Should().Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void GetAverageAgeOfAllMyMitarbeiter_repo_null_should_throw_ArgumentNullEx()
        {
            var act = () => MitarbeiterLogic.GetAverageAgeOfAllMyMitarbeiter(null);
            act.Should().Throw<ArgumentException>();
        }



        [TestMethod]
        public void CalcAge_Tests()
        {
            var dt1 = new DateTime(1, 1, 1);
            var dt2 = new DateTime(1, 1, 1);

            MitarbeiterLogic.CalcAge(dt1, dt2).Should().Be(0);
            MitarbeiterLogic.CalcAge(dt1, dt2.AddDays(364)).Should().Be(0);
            MitarbeiterLogic.CalcAge(dt1, dt2.AddDays(365)).Should().Be(1);
            MitarbeiterLogic.CalcAge(dt1, dt2.AddYears(40)).Should().Be(40);
        }
    }
}
