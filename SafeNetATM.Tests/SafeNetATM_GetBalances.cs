using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace SafeNetATM.Tests
{
    public class SafeNetATM_GetBalances
    {
        private readonly ATM _atm;

        public SafeNetATM_GetBalances()
        {
            _atm = new ATM();
        }

        [Fact]
        public void GetBalances_All()
        {
            Assert.True(_atm.GetBalances().First() == "$100 - 10");
        }

        [Fact]
        public void GetBalances_Hundreds()
        {
            var param = new int[] { 100 };

            Assert.True(_atm.GetBalances(param).First() == "$100 - 10");
        }

        [Fact]
        public void GetBalances_HundredsAndFifties()
        {
            var param = new int[] { 100, 50 };
            List<string> expectedResult = new List<string> { "$100 - 10", "$50 - 10" };

            Assert.Equal(_atm.GetBalances(param), expectedResult);
        }

        [Fact]
        public void GetBalances_InvalidInput()
        {
            var param = new int[] { 33 };
            List<string> expectedResult = null;

            Assert.Equal(_atm.GetBalances(param), expectedResult);
        }
    }
}
