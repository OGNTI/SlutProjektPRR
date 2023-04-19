using System.Text.RegularExpressions;

Random generator = new Random();

string name;
int age;
string location = "";
int turn = 1;

string action = "";
string subAction = "";

Console.WriteLine("What is the name and age of your character? (e.g. [Steve 30])");

bool questionAnswered = false;
while (!questionAnswered)
{
    string userInput = Console.ReadLine();  //get input
    string refinedInput = userInput.Trim(); //trim input

    bool hasSpace = refinedInput.Contains(" "); //check if input has space, instructed way of typing contains space

    Console.WriteLine("");

    if (!hasSpace)
    {
        Console.WriteLine("You did not enter your name and age in the correct way. (e.g. [Henry 62]) \nTry again.");
    }
    else
    {
        int pFrom = refinedInput.IndexOf(" "); //find the space and get position
        int pTo = refinedInput.LastIndexOf(""); //get whole string length

        name = refinedInput.Substring(0, pFrom); //get text in position 0 with length pFrom
        string unrefinedAge = refinedInput.Substring(pFrom, pTo - pFrom); //get text in position pFrom with length pTo-pFrom
        bool conversionSuccess1 = false;
        conversionSuccess1 = int.TryParse(unrefinedAge, out age); //check if userInput was input in instructed way

        string numbersOnly = Regex.Replace(unrefinedAge, "[^0-9.]", ""); //remove any non numbers
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

location = LocationChoice();

List<string> inventory = new List<string>();
inventory.Add(GetRandomInventory());
inventory.Add(GetRandomInventory());

Console.WriteLine($"Day {turn} - {location} [type \"help\" for help]\n ");
bool gaming = true;
while (gaming)
{
    GetAction();

    if (action == "" && subAction == "help")
    {
        Console.WriteLine("Play this game by typing actions like \"Go north\".\nThe following is a list of all available actions.\nCommands:\n -Go (will take 1 day)\n   north\n   south\n   east\n   west\n -Open\n   inventory\n");
    }
    else if (action == "go")
    {
        int b = generator.Next(1, 3);
        if (subAction == "north" || subAction == "south" || subAction == "east" || subAction == "west") //trick the user into thinking there is a difference which direction you go
        {
            if (location == "forest")
            {
                RandomForestEvent();
            }
        }

    }
    else if (action == "open")
    {
        if (subAction == "inventory")
        {
            Console.WriteLine("Inventory:");
            foreach (string item in inventory)
            {
                Console.WriteLine("-" + item);
            }
        }
    }




}



static string LocationChoice()
{
    string location = "";

    Console.WriteLine("Please choose a starting location. [Type the respective number]");

    bool questionAnswered = false;
    while (!questionAnswered)
    {
        Console.WriteLine("1. Forest \n2. Beach \n3. Swamp");

        string userInput = Console.ReadLine();
        Console.WriteLine("");

        bool conversionSuccess = false;
        conversionSuccess = int.TryParse(userInput, out int answer); //did the user follow the instructions

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

                if (has1 && has2 && has3) //did the user try choosing all options
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
            else if (hasForest || hasBeach || hasSwamp) //did user write in words instead of numbers
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

    return location;
}

static string GetRandomInventory() //start with random items in inventory
{
    Random generator = new Random();
    int a = generator.Next(1, 5);
    string item = "";

    if (a == 1)
    {
        item = "can";
    }
    else if (a == 2)
    {
        item = "old_boot";
    }
    else if (a == 3)
    {
        item = "rusty_shovel";
    }
    else if (a == 4)
    {
        item = "shiv";
    }


    return item;
}

void GetAction()
{
    string userInput = Console.ReadLine();
    string refinedInput = userInput.Trim();
    Console.WriteLine("");

    int pFrom = refinedInput.IndexOf(" ") + " ".Length; //get position of space and add 1 to it
    int pTo = refinedInput.LastIndexOf(""); 
    string unrefinedAction = refinedInput.Substring(0, pFrom);
    string refinedAction = unrefinedAction.Trim();
    action = refinedAction.ToLower();
    string unrefinedSubAction = refinedInput.Substring(pFrom, pTo - pFrom);
    subAction = unrefinedSubAction.ToLower();
}

static int NextTurn(int previousTurn)
{
    int newTurn = previousTurn + 1;

    return newTurn;
}

static void RandomForestEvent()
{
    Random generator = new Random();

    int c = generator.Next(1, 4);

    if (c == 1)
    {
        Console.WriteLine("You walked and walked for a day and found nothing.");
    }
    else if (c == 2)
    {
        Console.WriteLine("As you walk around in the woods you find an abandoned cargo container\nWhat do you do?");
    }
    else if (c == 3)
    {
        Console.WriteLine("");
    }

}









