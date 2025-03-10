using System;
using System.Collections.Generic;

class Animal
{
    protected string _name;
    public string Name { get { return _name; } set { _name = value; } }

    public Animal(string name)
    {
        _name = name;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("Insert Animal Sound Here");
    }
}

class Dog : Animal
{
    public Dog() : base("Dog") { }

    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }
}

class Cat : Animal
{
    public Cat() : base("Cat") { }

    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}

class Bird : Animal
{
    public Bird() : base("Bird") { }

    public override void MakeSound()
    {
        Console.WriteLine("Piu");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog(),
            new Cat(),
            new Bird()
        };

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
    }
}