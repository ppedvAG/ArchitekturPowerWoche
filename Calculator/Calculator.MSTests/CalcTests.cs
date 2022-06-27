namespace Calculator.MSTests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_2_and_4_results_6()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 4);

            //Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(2, 4, 6)]
        [DataRow(-2, -4, -6)]
        [DataRow(-2, 4, 2)]
        [DataRow(0, 0, 0)]
        public void Calc_Sum_OK(int a, int b, int exp)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [TestMethod]
        [DataRow(int.MaxValue, 1)]
        [DataRow(int.MinValue, -1)]
        public void Calc_Sum_MAX_or_MIN_throws(int a, int b)
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(a, b));

        }
    }
}