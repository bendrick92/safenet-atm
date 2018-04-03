using System;
using System.Collections.Generic;

namespace SafeNetATM
{
    public class ATM
    {
        public const int DefaultBillCount = 10;

        public int Hundreds { get; private set; }
        public int Fifties { get; private set; }
        public int Twenties { get; private set; }
        public int Tens { get; private set; }
        public int Fives { get; private set; }
        public int Ones { get; private set; }

        private int tempHundreds;
        private int tempFifties;
        private int tempTwenties;
        private int tempTens;
        private int tempFives;
        private int tempOnes;

        public ATM()
        {
            Restock();
        }

        public void Restock()
        {
            Hundreds = DefaultBillCount;
            Fifties = DefaultBillCount;
            Twenties = DefaultBillCount;
            Tens = DefaultBillCount;
            Fives = DefaultBillCount;
            Ones = DefaultBillCount;
        }

        public void Restock(int hundreds, int fifties, int twenties, int tens, int fives, int ones)
        {
            Hundreds = hundreds;
            Fifties = fifties;
            Twenties = twenties;
            Tens = tens;
            Fives = fives;
            Ones = ones;
        }

        public List<string> GetBalances(int[] bills)
        {
            List<string> balances = new List<string>();

            for (int i = 0; i < bills.Length; i++)
            {
                switch (bills[i])
                {
                    case 100:
                        balances.Add(String.Format("$100 - {0}", Hundreds));
                        break;
                    case 50:
                        balances.Add(String.Format("$50 - {0}", Fifties));
                        break;
                    case 20:
                        balances.Add(String.Format("$20 - {0}", Twenties));
                        break;
                    case 10:
                        balances.Add(String.Format("$10 - {0}", Tens));
                        break;
                    case 5:
                        balances.Add(String.Format("$5 - {0}", Fives));
                        break;
                    case 1:
                        balances.Add(String.Format("$1 - {0}", Ones));
                        break;
                    default:
                        return null;
                }
            }

            return balances;
        }

        public List<string> GetBalances()
        {
            List<string> balances = new List<string>();

            balances.Add(String.Format("$100 - {0}", Hundreds));
            balances.Add(String.Format("$50 - {0}", Fifties));
            balances.Add(String.Format("$20 - {0}", Twenties));
            balances.Add(String.Format("$10 - {0}", Tens));
            balances.Add(String.Format("$5 - {0}", Fives));
            balances.Add(String.Format("$1 - {0}", Ones));

            return balances;
        }

        public bool Withdraw(int amount)
        {
            tempHundreds = Hundreds;
            tempFifties = Fifties;
            tempTwenties = Twenties;
            tempTens = Tens;
            tempFives = Fives;
            tempOnes = Ones;

            while (amount >= 100 && tempHundreds > 0)
            {
                amount = TryWithdraw(100, amount);
            }

            while (amount >= 50 && tempFifties > 0)
            {
                amount = TryWithdraw(50, amount);
            }

            while (amount >= 20 && tempTwenties > 0)
            {
                amount = TryWithdraw(20, amount);
            }

            while (amount >= 10 && tempTens > 0)
            {
                amount = TryWithdraw(10, amount);
            }

            while (amount >= 5 && tempFives > 0)
            {
                amount = TryWithdraw(5, amount);
            }

            while (amount >= 1 && tempOnes > 0)
            {
                amount = TryWithdraw(1, amount);
            }

            if (amount == 0)
            {
                Hundreds = tempHundreds;
                Fifties = tempFifties;
                Twenties = tempTwenties;
                Tens = tempTens;
                Fives = tempFives;
                Ones = tempOnes;

                return true;
            }
            else
            {
                return false;
            }
        }

        public int TryWithdraw(int billSize, int amount)
        {
            switch (billSize)
            {
                case 100:
                    if (tempHundreds > 0)
                    {
                        amount = amount - 100;
                        tempHundreds--;
                    }
                    return amount;
                case 50:
                    if (tempFifties > 0)
                    {
                        amount = amount - 50;
                        tempFifties--;
                    }
                    return amount;
                case 20:
                    if (tempTwenties > 0)
                    {
                        amount = amount - 20;
                        tempTwenties--;
                    }
                    return amount;
                case 10:
                    if (tempTens > 0)
                    {
                        amount = amount - 10;
                        tempTens--;
                    }
                    return amount;
                case 5:
                    if (tempFives > 0)
                    {
                        amount = amount - 5;
                        tempFives--;
                    }
                    return amount;
                case 1:
                    if (tempOnes > 0)
                    {
                        amount = amount - 1;
                        tempOnes --;
                    }
                    return amount;
                default:
                    return amount;
            }
        }
    }
}
