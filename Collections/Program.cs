using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person { Name = "Naveed", Age = 22 },
            new Person { Name = "kabeer", Age = 24 },
            new Person { Name = "ishraq", Age = 243 },
            new Person { Name = "mubeen", Age = 232 },
            new Person { Name = "NDK", Age = 212 },
            new Person { Name = "Naveed", Age = 222 },
            new Person { Name = "kapoor", Age = 322 }
        };

        Console.WriteLine("..........Method Syntax..........");

        var query1 = people.Where(s => s.Age > 100).Select(s => s.Name);
        var query2 = people.Where(s => s.Age > 100).Select(s => new { s.Name, s.Age });

        Console.WriteLine("Query1:");
        foreach (var x in query1)
        {
            Console.WriteLine($"Name: {x}");
        }

        Console.WriteLine("Query2:");
        foreach (var x in query2)
        {
            Console.WriteLine($"Name: {x.Name}, Age: {x.Age}");
        }

        Console.WriteLine();
        Console.WriteLine("..........Query Syntax..........");

        var query3 = from s in people
                     where s.Age == 22
                     select s.Name;

        Console.WriteLine("Query3:");
        foreach (var x in query3)
        {
            Console.WriteLine($"Name: {x}");
        }

        var query4 = from c in people
                     where c.Name == "ishraq"
                     select new { c.Name, c.Age };

        Console.WriteLine("Query4:");
        foreach (var x in query4)
        {
            Console.WriteLine($"Name: {x.Name}, Age: {x.Age}");
        }

        Console.WriteLine();
        Console.WriteLine("..........IQueryable and IEnumerable..........");

        IQueryable<Person> methodSyntax = people.AsQueryable()
                                                .Where(std => std.Name == "ishraq");

        Console.WriteLine("IQueryable:");
        foreach (var student in methodSyntax)
        {
            Console.WriteLine($"Name is: {student.Name}");
        }

        IEnumerable<string> methodSyntax1 = people
                                            .Where(std => std.Name == "ishraq")
                                            .Select(std => std.Name);

        Console.WriteLine("IEnumerable<string>:");
        foreach (var name in methodSyntax1)
        {
            Console.WriteLine($"Name is: {name}");
        }
    }
}
