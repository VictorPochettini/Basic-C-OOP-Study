using System;

class Animal
{
    protected string _name;
    public string Name { get{return _name;} set{_name = value;} }

    public virtual void MakeSound()
    {
        Console.WriteLine("Insert Animal Sound Here");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}

class Bird : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Piu");
    }
}