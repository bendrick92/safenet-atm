# safenet-atm
Mock ATM .NET Core console application

## Installation
Clone this repository:
```git clone https://github.com/bendrick92/safenet-atm```

Be sure to restore the required packages before running.

## Usage
To run the unit tests:
```
cd SafeNetATM.Tests
dotnet test
```

To run the program:
```
cd SafeNetATM
dotnet run
```

Supported commands include:
* Q - Quits the console application
* R - Restocks the ATM to default balances (10 of each bill)
* I \<denominations\> - Displays current balances for indicated bills (i.e. `I $10 $20 $100)
* W \<dollar amount\> - Attempts to withdraw the requested amount
