using System;

class BankAccount
{
    private double _balance;
    public double Balance { get{return _balance;} set{_balance = value >= 0 ? value : 0;}}

    public void Deposit(double amount)
    {
        _balance += amount;
    }

    public void Withdraw(double amount)
    {
        if(amount > _balance)
        {
            Console.Error.WriteLine("Error: you don't have that money");
        }
        else
        {
            _balance -= amount;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount acc = new BankAccount();
        acc.Balance = 1000;

        acc.Deposit(200);
        acc.Withdraw(800);

        Console.WriteLine(acc.Balance);
    }
}