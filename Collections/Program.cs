using System;
using System.Collections.Generic;
public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Person other = (Person)obj;
        return Name == other.Name && Age == other.Age;
    }

    public override int GetHashCode()
    {
        return (Name, Age).GetHashCode();
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Person other = (Person)obj;
        return Name == other.Name && Age == other.Age;
    }

    public override int GetHashCode()
    {
        return (Name, Age).GetHashCode();
    }
}

public class Program
{  
   
    public static void Main()
    {
       
        Person p1 = new Person { Name = "Naveed", Age = 22 };
        Person p2 = new Person { Name = "Naveed", Age = 22 };
        Person p3 = new Person { Name = "Ali", Age = 25 };
        Student s = new Student { Name = "Ali", Age = 25 };


        List<Person> people= new List<Person> { p1,p2,p3 };
        List<Person> people1 = new List<Person> { p1, p2 };
        List<Student> student = new List<Student> { s };

        var unionok = people.Union(people1);
        foreach (var n in unionok) {

            Console.WriteLine($"{n.Name},{n.Age}");
        }
        Console.Write("...........................");

        var intersection = people.Intersect(people1);
        foreach (var n in intersection)
        {

            Console.WriteLine($"{n.Name},{n.Age}");
        }

        

        Person p4 = p1;
        Console.WriteLine($"p3.Equals(s): {p3.Equals(s)}");
        Console.WriteLine($"p1.Equals(p4): {p1.Equals(p4)}");
        Console.WriteLine($"people.Contains(p4): {people.Contains(p4)}");
        Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
        Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
        Console.WriteLine($"people.Contains(p2): {people.Contains(p2)}");
        Console.WriteLine($"people.Contains(p3): {people.Contains(p3)}");



        Console.WriteLine("........."); 
        Console.WriteLine("---- Hash Codes ----");
        Console.WriteLine($"p1 HashCode: {p1.GetHashCode()}");
        Console.WriteLine($"p2 HashCode: {p2.GetHashCode()}");
        Console.WriteLine($"p3 HashCode: {p3.GetHashCode()}");
        Console.WriteLine($"p4 HashCode: {p4.GetHashCode()}");



        
    }
}