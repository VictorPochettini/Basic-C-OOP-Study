using System;

class Vehicle
{
    protected string _make;
    public string Make { get{return _make;} set{_make = value;} }
    protected string _model;
    public string Model { get{return _model;} set{_model = value;}}
    protected int _year;
    public int Year { get{return _year;} set{_year = value<0?0:value;}}
}

class Car : Vehicle
{
    protected int _door;
    public int NumberOfDoors { get{return _door;} set{_door = value;}}
}

class Motorcycle : Vehicle
{
    protected string _side;
    public string HasSideCar { get{return _side;} set{_side = value;}}
}

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();
        car.Make = "BYD";
        car.Model = "Idk";
        car.Year = 2024;
        car.NumberOfDoors = 4;

        Motorcycle mc = new Motorcycle();
        mc.Make = "Yamaha";
        mc.Model = "Flex";
        mc.HasSideCar = "No";
    }
}