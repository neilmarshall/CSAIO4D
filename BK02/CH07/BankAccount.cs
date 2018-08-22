using System;

/*
Learning points from this program:

    1. Override base class methods by prefacing methods in the subclass with
       the 'new' keyword - see overriden method 'GetString'

    2. Call methods polymorphically using late binding by marking base class
       methods as 'virtual' and prefacing methods in the subclass with the
       'override' keyword - see overriden method 'Withdraw'
*/

// BankAccount -- Define a class that represents a simple account
public class BankAccount
{
    // Class variables
    public static int _nextAccountNumber = 1000;

    // Instance variables
    public int _accountNumber;
    public decimal _balance;

    // Properties
    public int AccountNumber {
        get{ return _accountNumber; }
        set{ _accountNumber = value; }
    }

    public decimal Balance => _balance;  // read-only property

    // Class Constructors
    public BankAccount() : this(0.0M) {}

    public BankAccount(decimal initialBalance)
    {
        _accountNumber = _nextAccountNumber++;
        _balance = initialBalance;
    }

    // Instance methods
    public void Deposit(decimal amount)
    {
        if (amount > 0.0M)
            _balance += amount;
    }

    public virtual decimal Withdraw(decimal withdrawal)
    {
        if (_balance <= withdrawal)
            withdrawal = _balance;

        _balance -= withdrawal;

        return withdrawal;
    }

    public string GetString()
    {
        return String.Format("#{0} = {1:C}", AccountNumber, Balance);
    }
}

// SavingsAccount -- A BankAccount that draws interest
public class SavingsAccount : BankAccount
{
    // Class variables
    public decimal withdrawalCharge = 1.5M;

    // Instance variables
    public double _interestRate;

    // Class Constructors
    public SavingsAccount(double interestRate) : this(interestRate, 0.0M) {}

    public SavingsAccount(double interestRate,
        decimal initialBalance) : base(initialBalance)
    {
        _interestRate = interestRate;
    }

    // Overriden methods
    new public string GetString()
    {
        string s = String.Format("#{0} = {1:C} ({2}%)",
            AccountNumber, Balance, _interestRate * 100);
        return s;
    }

    override public decimal Withdraw(decimal withdrawal)
    {
        return base.Withdraw(withdrawal + withdrawalCharge);
    }

    // Instance methods
    public void AccumulateInterest()
    {
        _balance *= (decimal)(1 + _interestRate);
    }
}

public class Program
{
    public static void MakeWithdrawal(BankAccount ba, decimal amount)
    {
        ba.Withdraw(amount);
    }

    public static void Main(string[] args)
    {
        // open a bank account
        BankAccount ba = new BankAccount(200);
        Console.WriteLine(ba.GetString());
        MakeWithdrawal(ba, 100);
        Console.WriteLine(ba.GetString());

        Console.WriteLine();

        // open a savings account
        SavingsAccount sa = new SavingsAccount(0.1, 200);
        Console.WriteLine(sa.GetString());
        MakeWithdrawal(sa, 100);
        Console.WriteLine(sa.GetString());
    }
}

