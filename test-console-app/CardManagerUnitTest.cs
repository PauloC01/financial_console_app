using console_app;
using System;
using Xunit;

namespace test_console_app
{
    public class CardManagerUnitTest
    {
        [Fact]
        public void CheckValue_ShouldReturn0()
        {
            var limite = 1000;
            var itemValue = 100;
            var res = CardManager.CheckValue(limite, itemValue);

            Assert.Equal(0, res);
        }

        [Fact]
        public void CheckValue_ShouldReturn1()
        {
            var limite = 1000;
            var itemValue = 2000;
            var res = CardManager.CheckValue(limite, itemValue);

            Assert.Equal(1, res);
        }
    }
}
