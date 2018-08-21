using System;

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

    public decimal Withdraw(decimal withdrawal)
    {
        if (_balance <= withdrawal)
            withdrawal = _balance;

        _balance -= withdrawal;

        return withdrawal;
    }

    public string BankAccountString()
    {
        return String.Format("#{0} = {1:C}", AccountNumber, Balance);
    }
}

// SavingsAccount -- A BankAccount that draws interest
public class SavingsAccount : BankAccount
{
    // Instance variables
    public double _interestRate;

    // Class Constructors
    public SavingsAccount(double interestRate) : this(interestRate, 0.0M) {}

    public SavingsAccount(double interestRate,
        decimal initialBalance) : base(initialBalance)
    {
        _interestRate = interestRate;
    }

    // Instance methods
    public void AccumulateInterest()
    {
        _balance *= (decimal)(1 + _interestRate);
    }

    public string SavingsAccountString()
    {
        string s = String.Format("#{0} = {1:C} ({2}%)",
            AccountNumber, Balance, _interestRate * 100);
        return s;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // open a bank account
        BankAccount ba = new BankAccount(20);

        ba.Deposit(10);
        Console.WriteLine(ba.BankAccountString());

        int i = 8;
        while (i-- > 0) {
            ba.Withdraw(6);
            Console.WriteLine(ba.BankAccountString());
        }

        Console.WriteLine();

        // open a savings account
        SavingsAccount sa = new SavingsAccount(0.06, 45);
        Console.WriteLine(sa.SavingsAccountString());
        sa.AccumulateInterest();
        Console.WriteLine(sa.SavingsAccountString());
        sa.AccumulateInterest();
        Console.WriteLine(sa.SavingsAccountString());
        sa.Deposit(10);
        Console.WriteLine(sa.SavingsAccountString());
        sa.Withdraw(15);
        Console.WriteLine(sa.SavingsAccountString());
        sa.AccumulateInterest();
        Console.WriteLine(sa.SavingsAccountString());
    }
}

