using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace SafeNetATM.Tests
{
    public class SafeNetATM_Withdraw
    {
        private readonly ATM _atm;

        public SafeNetATM_Withdraw()
        {
            _atm = new ATM();
        }

        [Fact]
        public void Withdraw_120()
        {
            _atm.Restock(1, 1, 0, 2, 0, 0);

            Assert.True(_atm.Withdraw(120));
        }
    }
}
