using System;
using System.Collections.Generic;
using System.Linq;

public class Person : List<string>
{
    public void display()
    {
        foreach (var item in this)
        {
            Console.WriteLine(item);
        }
    }
}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    // ✅ Override Equals to compare Name and Age
    public override bool Equals(object obj)
    {
        if (obj == null || obj is not Student other)
            return false;

        return Name == other.Name && Age == other.Age;
    }

    // ✅ Always override GetHashCode when you override Equals
   
}

public class StudentList : List<Student>
{
    public void ShowStudentList()
    {
        foreach (var item in this)
        {
            Console.WriteLine($"{item.Name},{item.Age}");
        }
    }

    // ✅ Compare two lists element by element
    public override bool Equals(object obj)
    {
        if (obj == null || obj is not StudentList other)
        {
            return false;
        }

        return this.SequenceEqual(other);
    }

   
}

public class Program
{
    public static void Main()
    {
        Person list = new Person();
        list.Add("Naveed");
        list.Add("Kabeer");
        list.Add("ishraq");
        list.Add("sartaj");
        list.display();

        StudentList list2 = new StudentList();
        list2.Add(new Student { Name = "Naveed", Age = 20 });
        list2.Add(new Student { Name = "kabeer", Age = 22 });
        list2.Add(new Student { Name = "Naveed", Age = 20 });
        list2.ShowStudentList();

        StudentList list3 = new StudentList();
        list3.Add(new Student { Name = "Naveed", Age = 20 });
        
        list3.Add(new Student { Name = "kabeer", Age = 22 });
        list3.Add(new Student { Age = 20 });
        list3.ShowStudentList();

        Console.WriteLine(list2.Equals(list3));
    }
}