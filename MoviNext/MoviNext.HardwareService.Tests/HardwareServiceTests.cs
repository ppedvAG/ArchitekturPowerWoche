using FluentAssertions;
using Moq;
using MoviNext.Model;
using MoviNext.Model.Contracts;

namespace MoviNext.HardwareService.Tests
{
    [TestClass]
    public class HardwareServiceTests
    {
        [TestMethod]
        public void GetUmrichterWithMostLeistung_3_Umrichter_should_return_number_2()
        {
            var u1 = new Umrichter() { Leistung = 2 };
            var u2 = new Umrichter() { Leistung = 12 }; 
            var u3 = new Umrichter() { Leistung = 7 };
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Umrichter>())
                .Returns(() => new[] { u1, u2, u3 }.AsQueryable());

            var hs = new HardwareService(mock.Object);

            hs.GetUmrichterWithMostLeistung().Leistung.Should().Be(12);
        }
    }
}