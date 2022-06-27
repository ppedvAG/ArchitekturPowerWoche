namespace Calculator.NUnitTests
{
    public class Tests
    {



        [Test]
        public void Calc_Sum_2_and_4_results_6()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 4);

            //Assert
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        [TestCase(int.MaxValue, 1)]
        [TestCase(int.MinValue, -1)]
        public void Calc_Sum_MAX_or_MIN_throws(int a, int b)
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(a, b));

        }
    }
}