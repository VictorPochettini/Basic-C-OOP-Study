using System;

class Program
{
    public void Quicksort(int[] array, int size)
    {
        pivot = size - 1;
        for(int i = 0; i < pivot; i++)
        {
            if(array[i] < array[pivot])
            {
                
            }
        }
    }
    static void Main(string[] args)
    {
        Console.Write("Insert the size for you array:");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];

        for(int i = 0; i < size; i++)
        {
            Console.WriteLine($"\nInsert the { i + 1 }# value of the array:");
            array[i] = int.Parse(Console.ReadLine());
        }
    }
}

