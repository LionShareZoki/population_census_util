﻿using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Linq;

(string, int, double)[] people;
people = new (string, int, double)[0];

while (true)
{
    Console.Clear();
    Console.WriteLine("Menu:");
    Console.WriteLine("1. InputData");
    Console.WriteLine("2. Census");
    Console.WriteLine("3. Exit");

    Console.Write("Enter your choice: ");
    string input = Console.ReadLine()!;
    bool isNumber = int.TryParse(input, out int number);

    if (isNumber)
    {
        if (number == (int)MenuOption.InputData)
        {
            Console.WriteLine("How many people will be interviewed?");
            int numberOfPeople = int.Parse(Console.ReadLine()!);
            LoopTheInput(numberOfPeople, ref people);
        }
        else if (number == (int)MenuOption.Census)
        {
            showCensusMenu();
            DisplayCensus(people);
        }
        else if (number == (int)MenuOption.Exit)
        {
            Environment.Exit(0);
        }
    }
}

void LoopTheInput(int numberOfPeople, ref (string, int, double)[] people)

{
    Array.Resize(ref people, numberOfPeople);
    for (int i = 0; i < numberOfPeople; i++)
    {
        GetInputData(ref people, i);
    }
    Console.Clear();
    Console.WriteLine("The results are saved. Press 2 to see the results.");
}
void showCensusMenu()
{
    Console.Clear();
    Console.WriteLine("Which result do you want to see?");
    Console.WriteLine("1. GenderRatio");
    Console.WriteLine("2. AgePyramid");
    Console.WriteLine("3. AverageAge");
    Console.WriteLine("4. AverageIncome");

    Console.Write("Enter your choice: ");
    string input = Console.ReadLine()!;
    bool isNumber = int.TryParse(input, out int number);

    if (isNumber)
    {
        if (number == (int)CensusOption.GenderRatio)
        {
            DisplayGenderRatio(people);
        }
        else if (number == (int)CensusOption.AgePyramid)
        {
            DisplayAgePyramid(people);
        }
        else if (number == (int)CensusOption.AverageAge)
        {
            DisplayAverageAge(people);
        }
        else if (number == (int)CensusOption.AverageIncome)
        {
            DisplayAverageIncome(people);
        }
    }
}

static void GetInputData(ref (string, int, double)[] people, int index)

{
    Console.Clear();
    Console.WriteLine("Tell me about yourself:");

    Console.Write("Enter gender: ");
    string gender = Console.ReadLine()!;

    Console.Write("Enter age: ");
    int age = int.Parse(Console.ReadLine()!);

    Console.Write("Enter income (in euro): ");
    double income = double.Parse(Console.ReadLine()!);

    people[index] = (gender, age, income);
}

static void DisplayCensus((string, int, double)[] people)

{
    Console.Clear();
    Console.WriteLine($"Number of people interviewed: {people.Length}");

    Console.WriteLine("Ages");
    foreach (var person in people)
    {
        Console.Write(person.Item2 + " ");
    }

    Console.WriteLine("\nIncomes");
    foreach (var person in people)
    {
        Console.Write(person.Item3 + " ");
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}
static void DisplayGenderRatio((string, int, double)[] people)

{
    Console.Clear();
    int males = 0;
    int females = 0;
    foreach (var person in people)
    {
        if (person.Item1.ToLower() == "male")
        {
            males++;
        }
        else if (person.Item1.ToLower() == "female")
        {
            females++;
        }
    }
    int total = males + females;
    double maleRatio = (double)males / total * 100;
    double femaleRatio = (double)females / total * 100;

    Console.WriteLine($"Number of people interviewed: {total}");
    Console.WriteLine($"Male: {maleRatio:F2}%");
    Console.WriteLine($"Female: {femaleRatio:F2}%");

    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

static void DisplayAgePyramid((string, int, double)[] people)

{
    int totalPeople = people.Length;
    int numChildren = people.Count(p => p.Item2 < 18);
    int numMature = people.Count(p => p.Item2 >= 18 && p.Item2 <= 60);
    int numElderly = people.Count(p => p.Item2 > 60);

    double pctChildren = numChildren * 100.0 / totalPeople;
    double pctMature = numMature * 100.0 / totalPeople;
    double pctElderly = numElderly * 100.0 / totalPeople;


    int numChildrenBars = (int)Math.Round(pctChildren / 10);
    int numMatureBars = (int)Math.Round(pctMature / 10);
    int numElderlyBars = (int)Math.Round(pctElderly / 10);


    Console.WriteLine("Age pyramid:");

   

    for (int i = 0; i < numChildrenBars; i++)
    {
        Console.Write("*");
    }
    Console.WriteLine();

    for (int i = 0; i < numMatureBars; i++)
    {
        Console.Write("*");
    }
    Console.WriteLine();

    for (int i = 0; i < numElderlyBars; i++)
    {
        Console.Write("*");
    }
    Console.WriteLine();


    //int[] ageCounts = new int[101];

    //foreach (var person in people)
    //{
    //    int age = person.Item2;
    //    if (age >= 0 && age <= 100)
    //    {
    //        ageCounts[age]++;
    //    }
    //}

    //int maxCount = ageCounts.Max();

    //for (int i = maxCount; i > 0; i--)
    //{
    //    for (int j = 0; j < ageCounts.Length; j++)
    //    {
    //        if (ageCounts[j] >= i)
    //        {
    //            Console.Write("# ");
    //        }
    //        else
    //        {
    //            Console.Write("  ");
    //        }
    //    }
    //    Console.WriteLine();
    //}

    //for (int i = 0; i < ageCounts.Length; i++)
    //{
    //    Console.Write($"{i,2} ");
    //}

    //Console.WriteLine();
    //Console.WriteLine("Press any key to continue...");
    //Console.ReadKey();
}

static void DisplayAverageAge((string, int, double)[] people)

{
    Console.Clear();
    double totalAge = 0;
    foreach (var person in people)
    {
        totalAge += person.Item2;
    }
    double averageAge = totalAge / people.Length;

    Console.WriteLine($"Number of people interviewed: {people.Length}");
    Console.WriteLine($"Average Age: {averageAge:F2}");

    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

static void DisplayAverageIncome((string, int, double)[] people)

{
    Console.Clear();
    Console.WriteLine("Average Income");

    double totalIncome = 0.0;
    foreach (var person in people)
    {
        totalIncome += person.Item3;
    }

    double averageIncome = totalIncome / people.Length;
    Console.WriteLine($"The average income of the people interviewed is {averageIncome:C}.");

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}


public enum MenuOption
{
    InputData = 1,
    Census = 2,
    Exit = 3
}

public enum CensusOption
{
    GenderRatio = 1,
    AgePyramid = 2,
    AverageAge = 3,
    AverageIncome = 4
}