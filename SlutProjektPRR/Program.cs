using System.Text.RegularExpressions;

bool alive = true;

string name;
int age;

bool questionAnswered;
string userInput;
string refinedUserInput;
string result = "error";


Console.WriteLine("What is the name and age of your character? (e.g. [Steve 30])");

questionAnswered = false;
while (!questionAnswered)
{
    userInput = Console.ReadLine();
    refinedUserInput = userInput.Trim();

    Console.WriteLine();
    bool containsSpace = refinedUserInput.Contains(" ");
    if (!containsSpace)
    {
        Console.WriteLine("You did not enter your name and age in the correct way. (e.g. [Henry 62]) \nTry again.");
    }
    else 
    {
        int pFrom = refinedUserInput.IndexOf(" ") + " ".Length;
        int pTo = refinedUserInput.LastIndexOf("");

        string unrefinedName = refinedUserInput.Substring(0,pFrom);
        name = unrefinedName.Trim();
        result = refinedUserInput.Substring(pFrom, pTo - pFrom);
        bool conversionSuccess1 = false;
        conversionSuccess1 = int.TryParse(result, out age);

        string numberOnly = Regex.Replace(result, "[^0-9.]", "");
        bool conversionSuccess2 = false;
        conversionSuccess2 = int.TryParse(numberOnly, out age);

        if(!conversionSuccess2)
        {
            Console.WriteLine("You did not enter age as a number. \nTry again.");
        }
        else if (conversionSuccess2 && !conversionSuccess1)
        {
            Console.WriteLine("You did not enter age in the correct way but I got numbers from it so fuck you, I'm using it.");
            questionAnswered = true;
        }
        else if (conversionSuccess2)
        {
            questionAnswered = true;
        }
        
        if (questionAnswered)
        {
            Console.WriteLine($" \nYour characters name is {name} and they're {age} years old. \nPlease press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}









while (alive)
{


}