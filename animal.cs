using System;

class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("动物发出声音");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("狗在汪汪叫");
    }
}
class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("猫在喵喵叫");
    }
}

class Program
{
    static void Main()
    {
     Dog d = new Dog();
     Cat c = new Cat();

     d.MakeSound();
     c.MakeSound();

    }
}