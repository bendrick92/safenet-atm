using System;
using Xunit;

namespace SafeNetATM.Tests
{
    public class SafeNetATM_Restock
    {
        private readonly ATM _atm;

        public SafeNetATM_Restock()
        {
            _atm = new ATM();
        }

        [Fact]
        public void Restock()
        {
            _atm.Restock();

            Assert.True(_atm.Hundreds == ATM.DefaultBillCount);
            Assert.True(_atm.Fifties == ATM.DefaultBillCount);
            Assert.True(_atm.Twenties == ATM.DefaultBillCount);
            Assert.True(_atm.Tens == ATM.DefaultBillCount);
            Assert.True(_atm.Fives == ATM.DefaultBillCount);
            Assert.True(_atm.Ones == ATM.DefaultBillCount);
        }
    }
}
