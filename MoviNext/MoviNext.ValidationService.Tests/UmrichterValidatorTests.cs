using FluentAssertions;
using MoviNext.Model;

namespace MoviNext.ValidationService.Tests
{
    [TestClass]
    public class UmrichterValidatorTests
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(100)]
        [DataRow(999)]
        public void Spannuung_valid(int spannung)
        {
            var validator = new UmrichterValidator();
            var ur = new Umrichter() { Spannung = spannung, Frequenz = 1, Leistung = 1, Version = 1, Steuerung = new Steuerung() };
            validator.Validate(ur).IsValid.Should().BeTrue();
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(1000)]
        public void Spannung_invalid(int spannung)
        {
            var validator = new UmrichterValidator();
            var ur = new Umrichter() { Spannung = spannung, Frequenz = 1, Leistung = 1, Version = 1, Steuerung = new Steuerung() };
            var result = validator.Validate(ur);
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.First().PropertyName.Should().Be(nameof(Umrichter.Spannung));
        }
    }
}