using Microsoft.QualityTools.Testing.Fakes;


namespace TDDBank.Tests
{
    public class OpeningHoursTests
    {
        [Theory]
        [InlineData(2022, 06, 27, 10, 30, true)]//mo
        [InlineData(2022, 06, 27, 10, 29, false)]//mo
        [InlineData(2022, 06, 27, 10, 31, true)] //mo
        [InlineData(2022, 06, 27, 18, 59, true)] //mo
        [InlineData(2022, 06, 27, 19, 00, false)] //mo
        [InlineData(2022, 07, 2, 13, 0, true)] //sa
        [InlineData(2022, 07, 2, 16, 0, false)] //sa
        [InlineData(2022, 07, 3, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.Equal(result, oh.IsOpen(dt));
        }

        [Fact]
        public void OpeningHours_IsNowOpen()
        {
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(1111, 11, 11);
                var oh = new OpeningHours();
                Assert.False(oh.IsNowOpen());

                System.IO.Fakes.ShimStreamReader.AllInstances.ReadLine = x => "Hallo Welt";


            }
        }

        [Fact]
        public void OpeningHours_ReadOpeningHours()
        {
            using (ShimsContext.Create())
            {
                int c = 0;
                System.IO.Fakes.ShimStreamReader.ConstructorString = (sr, f) => { };
                System.IO.Fakes.ShimStreamReader.AllInstances.ReadLine = x => "Hallo Welt";
                System.IO.Fakes.ShimStreamReader.AllInstances.EndOfStreamGet = x => c++ > 3;
                var oh = new OpeningHours();

                oh.ReadOpeningHours();

            }
        }
    }
}
