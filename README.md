# Population Census Util

This code is a simple console application for conducting a census. It allows the user to input data about a group of people and then view various statistics about that group, including gender ratio, age pyramid, average age, and average income.

## How to use
To run the program, simply compile and execute the code in a C# environment such as Visual Studio or .NET Core.

Upon execution, the user will be presented with a menu that includes three options:

InputData: to input data about a group of people
Census: to view statistics about the group
Exit: to exit the program
If the user selects "InputData," they will be prompted to enter the number of people they want to interview. Once this is entered, the program will prompt the user to input information about each person, including gender, age, and income.

If the user selects "Census," they will be presented with a submenu that allows them to select which statistic they want to view.

## Code structure
The code uses a while loop to continually prompt the user to enter a menu choice until they select "Exit." The loop calls different methods depending on the user's selection.

The LoopTheInput method is called when the user selects "InputData." It prompts the user for the number of people they want to interview and then loops through that number of times, calling the GetInputData method for each person.

The GetInputData method prompts the user to enter information about a single person, including their gender, age, and income. It uses a while loop to ensure that the user enters valid input.

The showCensusMenu method is called when the user selects "Census." It presents the user with a submenu that allows them to select which statistic they want to view. It uses a while loop to ensure that the user enters valid input.

The other methods, including DisplayGenderRatio, DisplayAgePyramid, DisplayAverageAge, and DisplayAverageIncome, are called depending on the user's selection in the showCensusMenu method. These methods calculate and display the desired statistic.
