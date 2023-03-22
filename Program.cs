string[] genders = new string[0];
int[] ages = new int[0];
double[] incomes = new double[0];

while (true)
{
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
            LoopTheInput(numberOfPeople);
            Console.WriteLine($"genders are: {genders}");
            Console.WriteLine($"genders are: {ages}");
            Console.WriteLine($"genders are: {incomes}");

        }
    }
}

void LoopTheInput(int numberOfPeople)
{
    for (int i = 0; i < numberOfPeople; i++)
    {
        GetInputData();
    }
    

}

static void GetInputData()
{
    Console.Clear();
    Console.WriteLine("Tell me about yourself:");

    Console.Write("Enter gender: ");
    string gender = Console.ReadLine()!;
    string[] genders = new string[1];
    genders[0] = gender;
   

    Console.Write("Enter age: ");
    string ageInput = Console.ReadLine()!;
    int age = int.Parse(ageInput);
    int[] ages = new int[1];
    ages[0] = age;
    


    Console.Write("Enter income: ");
    string incomeInput = Console.ReadLine()!;
    double income = double.Parse(incomeInput);
    double[] incomes = new double[1];
    incomes[0] = income;

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
