using System;

class Vehicle
{
    private int speed_;
    public int Speed { get{return value;} set{speed_ = value>0?value:0;}}

    public virtual void DisplayInfo()
    {
        Console.WriteLine(Speed);
    }
}

class Car : Vehicle
{
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("这是一辆汽车。");
    }
}

class Bicycle : Vehicle
{
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("这是一辆自行车。");
    }
}

class Program
{
    static void Main()
    {
        Bicycle b = new Bicycle;
        Car c = new Car;
    }
}