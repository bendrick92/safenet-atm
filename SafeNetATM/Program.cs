using System;
using System.Collections.Generic;

namespace SafeNetATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();

            while (true)
            {
                string input = RequestInput(atm);
                if (input == "Q")
                {
                    break;
                }
            }
        }

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static string[] Read()
        {
            return Console.ReadLine().Split();
        }

        static string RequestInput(ATM atm)
        {
            string[] input = Read();
            string command = "";
            int[] parameters = new int[input.Length - 1];
            List<string> balances = new List<string>();

            if (input.Length > 0)
            {
                command = input[0].ToUpper();
                
                if (input.Length > 1)
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        parameters[i - 1] = Int32.Parse(input[i].Replace("$", ""));
                    }
                }
            }

            switch (command)
            {
                case "HELP":
                    Print("Q - Quits the program");
                    Print("R - Restocks ATM");
                    Print("I <denominations> - Displays current balances");
                    Print("W <dollar amount> - Withdraw requested amount");
                    break;
                case "Q":
                    break;
                case "R":
                    atm.Restock();
                    balances = atm.GetBalances();
                    Print("Machine balance:");
                    foreach (var balance in balances)
                    {
                        Print(balance);
                    }
                    break;
                case "I":
                    if (parameters.Length > 0)
                    {
                        balances = atm.GetBalances(parameters);
                    }
                    else
                    {
                        balances = atm.GetBalances();
                    }
                    Print("Machine balance:");
                    if (balances != null)
                    {
                        foreach (var balance in balances)
                        {
                            Print(balance);
                        }
                    }
                    else
                    {
                        Print("Failure: Invalid command");
                    }
                    break;
                case "W":
                    int withdrawlAmount = 0;
                    if (parameters.Length == 1)
                    {
                        withdrawlAmount = parameters[0];
                    }

                    if (atm.Withdraw(withdrawlAmount))
                    {
                        Print(String.Format("Success: Dispensed ${0}", withdrawlAmount));
                        balances = atm.GetBalances();
                        Print("Machine balance:");
                        foreach (var balance in balances)
                        {
                            Print(balance);
                        }
                    }
                    else
                    {
                        Print("Failure: Insufficient funds");
                    }
                    break;
                default:
                    Print("Failure: Invalid command");
                    break;
            }

            return command;
        }
    }
}
