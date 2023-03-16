using System.Text.RegularExpressions;

string name;
int age;
string location;

Console.WriteLine("What is the name and age of your character? (e.g. [Steve 30])");

bool questionAnswered = false;
while (!questionAnswered)
{
    string userInput = Console.ReadLine();
    Console.WriteLine("");
    string refinedInput = userInput.Trim();

    bool hasSpace = refinedInput.Contains(" ");

    if (!hasSpace)
    {
        Console.WriteLine("You did not enter your name and age in the correct way. (e.g. [Henry 62]) \nTry again.");
    }
    else
    {
        int pFrom = refinedInput.IndexOf(" ") + " ".Length;
        int pTo = refinedInput.LastIndexOf("");

        string unrefinedName = refinedInput.Substring(0, pFrom);
        name = unrefinedName.Trim();
        string unrefinedAge = refinedInput.Substring(pFrom, pTo - pFrom);
        bool conversionSuccess1 = false;
        conversionSuccess1 = int.TryParse(unrefinedAge, out age);

        string numbersOnly = Regex.Replace(unrefinedAge, "[^0-9.]", "");
        bool conversionSuccess2 = false;
        conversionSuccess2 = int.TryParse(numbersOnly, out age);

        if (!conversionSuccess2)
        {
            Console.WriteLine("You did not enter age as a number. \nTry again.");
        }
        else if (conversionSuccess2 && !conversionSuccess1)
        {
            Console.WriteLine("You did not enter age in the correct way but I got numbers so fuck you, I'm using it.");
            questionAnswered = true;
        }
        else if (conversionSuccess2)
        {
            questionAnswered = true;
        }

        if (questionAnswered)
        {
            Console.WriteLine($"Your characters name is {name} and they're {age} years old. \nPlease press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}


Console.WriteLine("Please choose a starting location. [Type the respective number]");

questionAnswered = false;
while (!questionAnswered)
{
    Console.WriteLine("1. Forest \n2. Beach \n3. Swamp");

    string userInput = Console.ReadLine();
    Console.WriteLine("");

    bool conversionSuccess = false;
    conversionSuccess = int.TryParse(userInput, out int answer);

    if (conversionSuccess)
    {
        Console.Clear();

        if (answer == 1)
        {
            location = "forest";
            questionAnswered = true;
        }
        else if (answer == 2)
        {
            location = "beach";
            questionAnswered = true;
        }
        else if (answer == 3)
        {
            location = "swamp";
            questionAnswered = true;
        }
        else
        {
            bool has1 = userInput.Contains("1");
            bool has2 = userInput.Contains("2");
            bool has3 = userInput.Contains("3");

            if (has1 && has2 && has3)
            {
                Console.WriteLine("You can not answer with all options you dumb fuck. \nTry again.");
            }
            else
            {
                Console.WriteLine("That was not an option. \nTry again.");
            }
        }
    }
    else if (!conversionSuccess)
    {
        Console.Clear();

        string refinedInput = userInput.ToLower();

        bool hasForest = refinedInput.Contains("forest");
        bool hasBeach = refinedInput.Contains("beach");
        bool hasSwamp = refinedInput.Contains("swamp");

        if (hasForest && hasBeach && hasSwamp)
        {
            Console.WriteLine("You can not answer with all options you dumb fuck. \nTry again.");
        }
        else if (hasForest && hasBeach)
        {
            Console.WriteLine("You can not answer with multiple options you dumb fuck. \nTry again.");
        }
        else if (hasForest && hasSwamp)
        {
            Console.WriteLine("You can not answer with multiple options you dumb fuck. \nTry again.");
        }
        else if (hasBeach && hasSwamp)
        {
            Console.WriteLine("You can not answer with multiple options you dumb fuck. \nTry again.");
        }
        else if (!hasForest && !hasBeach && !hasSwamp)
        {
            Console.WriteLine("That was not an option. \nTry again.");
        }
        else if (hasForest || hasBeach || hasSwamp)
        {
            Console.WriteLine("You did not answer in the instructed way but that was expected.");
            Console.Clear();

            if (hasForest)
            {
                location = "forest";
                questionAnswered = true;
            }
            else if (hasBeach)
            {
                location = "beach";
                questionAnswered = true;
            }
            else if (hasSwamp)
            {
                location = "swamp";
                questionAnswered = true;
            }
        }
    }
}


























