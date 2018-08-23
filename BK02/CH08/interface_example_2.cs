using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>{ new Cat(), new Cobra() };
        foreach(Animal animal in animals)
        {
            animal.Eat("oranges");
            animal.Sleep(6);
        }

        List<Robot> robots = new List<Robot> { new Robocat(), new Robozilla() };
        foreach(Robot robot in robots)
        {
            robot.LiftObject();
        }

        List<IPet> pets = new List<IPet> { new Cat(), new Robocat() };
        foreach(IPet pet in pets)
        {
            pet.AskForStrokes();
            pet.DoTricks();
        }
    }
}

public class Cat : Animal, IPet
{
    public override int NumberOfLegs { get { return 4; } }

    public string Name { get; set; }

    public override void Eat(string food)
    {
        Console.WriteLine("Eating {0}!", food);
    }

    public override void Sleep(int hours)
    {
        Console.WriteLine("Slept {0} hours!", hours);
    }

    public void AskForStrokes()
    {
        Console.WriteLine("Stroke me!");
    }

    public void DoTricks()
    {
        Console.WriteLine("Tricks being performed!");
    }
}

public class Cobra : Animal
{
    public override int NumberOfLegs { get { return 4; } }

    public override void Eat(string food)
    {
        Console.WriteLine("Eating {0}!", food);
    }

    public override void Sleep(int hours)
    {
        Console.WriteLine("Sleept {0} hours!", hours);
    }
}

public class Robocat : Robot, IPet
{
    public override int NumberOfLegs { get { return 4; } }

    public string Name { get; set; }

    public override void LiftObject()
    {
        Console.WriteLine("Lifting object!");
    }

    public void AskForStrokes()
    {
        Console.WriteLine("Stroke me!");
    }

    public void DoTricks()
    {
        Console.WriteLine("Tricks being performed!");
    }
}

public class Robozilla : Robot
{
    public override void LiftObject()
    {
        Console.WriteLine("Lifting object!");
    }

    public override int NumberOfLegs { get { return 2; } }
}

public abstract class Animal
{
    public abstract void Eat(string food);
    public abstract void Sleep(int hours);
    public abstract int NumberOfLegs { get; }
}

public abstract class Robot
{
    public abstract void LiftObject();
    public abstract int NumberOfLegs { get; }
}

interface IPet
{
    void AskForStrokes();
    void DoTricks();
    int NumberOfLegs { get; }
    string Name { get; set; }
}

