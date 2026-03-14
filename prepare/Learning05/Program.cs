using System;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 4),
            new Rectangle("Blue", 5,3),
            new Circle("Green", 2.5),
        };
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} has an area of {shape.GetArea()}:  ");
        }
    }
    
}