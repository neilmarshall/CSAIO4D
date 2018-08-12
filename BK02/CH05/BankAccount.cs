using System;

public class Program
{
    public static void Main(string[] args)
    {
        //open a bank account
        BankAccount ba = new BankAccount();

        ba.Deposit(10);
        Console.WriteLine(ba.GetString());

        ba.Withdraw(6);
        Console.WriteLine(ba.GetString());
    }
}

// BankAccount -- Define a class that represents a simple account
public class BankAccount
{
    private static int _nextAccountNumber = 1000;
    private decimal _balance;  // maintain the balance as a single decimal variable

    // Class Constructor
    public BankAccount()
    {
        AccountNumber = ++_nextAccountNumber;
        _balance = 0.0M;
    }

    public int AccountNumber {get; set;}  // note use of shorthand property definition

    public decimal Balance => _balance;  // note use of expression-bodied property accessor

    // Deposit -- Any positive deposit is allowed
    public void Deposit(decimal amount)
    {
        if (amount > 0.0M)
        {
            _balance += amount;
        }
    }

    // Withdraw -- any amount up to the current value of _balance can be withdrawn
    public decimal Withdraw(decimal withdrawal)
    {
        if (_balance <= withdrawal)
        {
            withdrawal = _balance;
        }
        _balance -= withdrawal;
        return withdrawal;
    }

    // GetString -- return the account data as a string
    public string GetString()
    {
        string s = String.Format("#{0} = {1:C}", AccountNumber, Balance);
        return s;
    }
}
