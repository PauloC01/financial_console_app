using console_app;
using Xunit;

namespace test_console_app
{
    public class InvestManagerUnitTest
    {
        [Fact]
        public void CalculateInvestiment_WhenSelicSmaller()
        {
            var investValue = 100;
            var time = 3;
            double selic = 0.08;
            double tr = 0.48 / 100;

            var res = InvestmentManager.CalculateInvestiment(investValue, time, selic, tr);

            Assert.NotEmpty(res.MonthlyMessageList);

            Assert.Equal(102.86, res.Result);
        }

        [Fact]
        public void CalculateInvestiment_WhenSelicBigger()
        {
            var investValue = 100;
            var time = 1;
            double selic = 0.1;
            double tr = 0.48 / 100;

            var res = InvestmentManager.CalculateInvestiment(investValue, time, selic, tr);

            Assert.NotEmpty(res.MonthlyMessageList);

            Assert.Equal(100.98, res.Result);
        }
    }
}
