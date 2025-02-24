using System;

class Student
{
    public int Age { get; set; }
    public string Name{ get; set; }
    public string Grade{ get; set; }

    public Student(int age, string name, string grade)
    {
        this.Age = age;
        this.Name = name;
        this.Grade = grade;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"年龄：{Age}\n姓名：{Name}\n年级：{Grade}\n");
    }   
}

class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student(15,"Victor","A");
        Student s2 = new Student(20,"Roberto","B");

        s1.DisplayInfo();
        s2.DisplayInfo();
    }
}