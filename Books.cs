using System;


class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }

    public Book(string title, string author, int pages)
    {
        this.Title = title;
        this.Author = author;
        this.Pages = pages;
    }
    public Book()
    {
        this.Title = "No Title";
        this.Author = "No Author";
        this.Pages = 0;
    }
    public void Print()
    {
        Console.WriteLine("Title: {0}", this.Title);
        Console.WriteLine("Author: {0}", this.Author);
        Console.WriteLine("Pages: {0}", this.Pages);
    }
}
class Program
{
    public void RegisterBook(class Book book)
    {
        Console.WriteLine("How many books do you want to register?\n");
        int n = int.Parse(Console.ReadLine());
        string option;
        Book[] book = new Book[n] ;
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter the title of the book: \n");
            book[i].Title = Console.Readline;
            Console.WriteLine("Enter the author of the book: \n");
            book[i].Author = Console.Readline;
            Console.WriteLine("Enter the number of pages of the book: \n");
            book[i].Pages = int.Parse(Console.Readline);
            Console.WriteLine("Check the informations of the book: \n");
            book[i].Print();
            Console.WriteLine("Are they correct? (Y/N)\n");
            bool option = Console.Readline;
            if(option == 'N')
            {
                Console.WriteLine("Enter the title of the book: \n");
                book[i].Title = Console.Readline;
                Console.WriteLine("Enter the author of the book: \n");
                book[i].Author = Console.Readline;
                Console.WriteLine("Enter the number of pages of the book: \n");
                book[i].Pages = int.Parse(Console.Readline);
                Console.WriteLine("Check the informations of the book: \n");
                book[i].Print();
            }
        }
    }

    void Search(class Book book)
    {
        Console.WriteLine("Enter the title of the book you want to search: \n");
        string title = Console.Readline;
        for(int i = 0; i < book.Length; i++)
        {
            if(title == book[i].Title)
            {
                Console.WriteLine("Book found!\n");
                book[i].Print();
            }
            else
            {
                Console.WriteLine("Book not found!\n");
            }
        }
    }
    static void Main(string[] args)
    {
        Book book = new Book();
        Program program = new Program();
        
        Console.WriteLine("1 - Register a book\n2 - Search a book\n");
        int option = int.Parse(Console.ReadLine());
        if(option == 1)
        {
            program.RegisterBook(book);
        }
        else if(option == 2)
        {
            program.Search(book);
        }
    }
}