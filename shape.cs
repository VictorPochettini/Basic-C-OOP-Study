using System;

abstract class Shape
{
    protected string _name;
    public string Name {get{ return _name;} set{_name = value;}}
    public abstract float CalculateArea();
}

class Circle : Shape
{
    private int _radius;
    public int Radius { get{return _radius;} set{_radius = value>0?value:0;} }
    
    private float _area;
    public float Area { get{return _area;} set{_area = value>0?value:0;} }
    public override float CalculateArea()
    {
        Area = 3.1415f * Radius * Radius;
        return Area;
    }
}

class Rectangle : Shape
{
    private int _width;
    public int Width { get{return _width;} set{_width = value>0?value:0;} }
    
    private int _height;
    public int Height { get{return _height;} set{_height = value>0?value:0;} }
    
    private float _area;
    public float Area { get{return _area;} set{_area = value>0?value:0;} }
    public override float CalculateArea()
    {
        Area = Width * Height;
        return Area;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rec = new Rectangle();
        rec.Name = "Rectangle";
        rec.Width = 3;
        rec.Height = 10;
        rec.CalculateArea();

        Circle circle = new Circle();
        circle.Name = "Circle";
        circle.Radius = 4;
        circle.CalculateArea();

        Console.WriteLine(rec.Area + "\n");

        Console.WriteLine(circle.Area + "\n");
    }
}