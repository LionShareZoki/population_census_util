while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. InputData");
    Console.WriteLine("2. Census");
    Console.WriteLine("3. Exit");

    Console.Write("Enter your choice: ");
    string input = Console.ReadLine();
    bool isNumber = int.TryParse(input, out int number);

    if (isNumber)
    {
        if (number == (int)MenuOption.InputData)
        {
            Console.WriteLine("yo");
        }
    }
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
