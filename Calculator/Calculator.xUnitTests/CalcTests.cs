namespace Calculator.xUnitTests
{
    public class CalcTests
    {
        [Fact]
        public void Calc_Sum_2_and_4_results_6()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 4);

            //Assert
            Assert.Equal(6, result);
        }
   

        [Theory]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, -1)]
        public void Calc_Sum_MAX_or_MIN_throws(int a, int b)
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(a, b));

        }
    }
}