Tuple<string, int, double>[] people = new Tuple<string, int, double>[0];

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
            DisplayCensus(people);
        }
        else if (number == (int)MenuOption.Exit)
        {
            Environment.Exit(0);
        }
    }
}

void LoopTheInput(int numberOfPeople, ref Tuple<string, int, double>[] people)
{
    Array.Resize(ref people, numberOfPeople);
    for (int i = 0; i < numberOfPeople; i++)
    {
        GetInputData(ref people, i);
    }
    Console.Clear();
    Console.WriteLine("The results are saved. Press 2 to see the results.");
}

static void GetInputData(ref Tuple<string, int, double>[] people, int index)
{
    Console.Clear();
    Console.WriteLine("Tell me about yourself:");

    Console.Write("Enter gender: ");
    string gender = Console.ReadLine()!;

    Console.Write("Enter age: ");
    int age = int.Parse(Console.ReadLine()!);

    Console.Write("Enter income (in euro): ");
    double income = double.Parse(Console.ReadLine()!);

    people[index] = Tuple.Create(gender, age, income);
}

static void DisplayCensus(Tuple<string, int, double>[] people)
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
