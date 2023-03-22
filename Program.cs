
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

while(true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Census");
    Console.WriteLine("2. Average Age");
    Console.WriteLine("3. Exit");

    Console.Write("Enter your choice: ");
    string input = Console.ReadLine();
}