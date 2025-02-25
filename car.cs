using System;

class Car
{
    public string Brand { get; set;}
    public string Model { get; set;}
    public int Year { get; set;}

    private int speed_;
    public int Speed { get{return speed_;} set{speed_ = value>0?value:0;}}

    public void Accelarate(int a)
    {
        Speed += a;
    }
     public void Brake(int a)
    {
        Speed -= a;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"品牌：{Brand}\n型号：{Model}\n年份：{Year}\n当前速度：{Speed}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car c = new Car();
        c.Brand = "Toyota";
        c.Model = "Corolla";
        c.Year = 2020;
        c.Speed = 0;

        c.Accelarate(20);
        c.Brake(2);

        c.DisplayInfo();

    }
}