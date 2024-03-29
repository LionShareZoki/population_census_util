﻿

using static System.Runtime.InteropServices.JavaScript.JSType;

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
        }
        else if (number == (int)MenuOption.Exit)
        {
            Environment.Exit(0);
        }
    }
    else if (!isNumber)
    {
        
        Console.WriteLine("You will have to enter a number. Do you want to try again?");
        Console.ReadLine();
        
    }
    else if (input == "")
    {
      Console.WriteLine("You will have to enter a number. Do you want to try again?"); 
      Console.ReadLine(); 
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
    Console.WriteLine("Press 2 to see the results.");
    Console.WriteLine("Press any key to go to main menu");
    string input = Console.ReadLine()!;
    bool isNumber = int.TryParse(input, out int number);
    if (number == 2)
    {
        showCensusMenu();
    }
}
void showCensusMenu()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Which result do you want to see?");
        Console.WriteLine("1. GenderRatio");
        Console.WriteLine("2. AgePyramid");
        Console.WriteLine("3. AverageAge");
        Console.WriteLine("4. AverageIncome");

        Console.Write("Enter your choice: ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("You need to enter a number. Press any key to try again...");
            Console.ReadKey();
            continue;
        }

        if (!int.TryParse(input, out int number))
        {
            Console.WriteLine("You need to enter a valid number. Press any key to try again...");
            Console.ReadKey();
            continue;
        }

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
        else
        {
            Console.WriteLine("You need to enter a valid number between 1 and 4. Press any key to try again...");
            Console.ReadKey();
            continue;
        }

        break;
    }
}

static void GetInputData(ref (string, int, double)[] people, int index)

{
    Console.Clear();
    Console.WriteLine("Hello!");
    Console.WriteLine("Tell me about yourself:");
    Console.WriteLine("");

    string gender;
    do
    {
        Console.Write("Enter gender (male/female): ");
        gender = Console.ReadLine()!;
        if (gender.ToLower() != "male" && gender.ToLower() != "female")
        {
            Console.WriteLine("Gender can only be male or female. Please enter your answer again.");
        }
    } while (gender.ToLower() != "male" && gender.ToLower() != "female");

    Console.Write("Enter age: ");
    int age;
    while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
    {
        Console.WriteLine("Age must be a positive number. Please enter a valid age: ");
    }

    Console.Write("Enter income (in euro): ");
    double income;

    while (!double.TryParse(Console.ReadLine(), out income))
    {
        Console.WriteLine("Invalid input! Income must be a number. Please try again.");
        Console.Write("Enter income (in euro): ");
    }

    people[index] = (gender, age, income);
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
    Console.WriteLine($"Male to female ratio is {maleRatio:F2}% : {femaleRatio:F2}% ");
    

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

    Console.WriteLine("Age pyramid:");

    int numChildBars = (int)(pctChildren / 10);
    int numMatureBars = (int)(pctMature / 10);
    int numElderlyBars = (int)(pctElderly / 10);
    for (int i = 0; i < 10; i++)
    {
        if (i < numElderlyBars)
        {
            Console.Write("█");
        }
        else
        {
            Console.Write(" ");
        }
    }

    

    Console.WriteLine(" ");

    for (int i = 0; i < 10; i++)
    {
        if (i < numMatureBars)
        {
            Console.Write("█");
        }
        else
        {
            Console.Write(" ");
        }
    }

    Console.WriteLine(" ");

    for (int i = 0; i < 10; i++)
    {
        if (i < numChildBars)
        {
            Console.Write("█");
        }
        else
        {
            Console.Write(" ");
        }
    }



    Console.WriteLine();


    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
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