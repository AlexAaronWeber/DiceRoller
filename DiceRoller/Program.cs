//----------------------------MAIN----------------------------

Console.WriteLine("Welcome to the John Cena Casino");

//prompt user
Console.WriteLine("How many sides do you want on a pair of dice? (Must be 2 or greater)");

//take valid input
int dice = getDice();

//looping
bool looping = true;
while (looping)
{
    //convert to random numbers for the rolls
    int roll1 = getRandom(dice);
    int roll2 = getRandom(dice);

    //display the roll
    Console.WriteLine($"You rolled a {roll1} and a {roll2} ({roll1 + roll2} total)");
    if (dice == 6)
    {
        DisplayCombo(roll1, roll2);
    }
    else if (dice == 20)
    {
        DNDCombos(roll1, roll2);
    }
    looping = GetContinue();
}


//testing
//DisplayCombo(1, 1);
//DisplayCombo(1, 2);
//DisplayCombo(6, 6);
//DisplayCombo(3, 4);
//DisplayCombo(6, 5);


//---------------------------METHODS--------------------------
//1 Get a random number
static int getRandom(int sides)
{
    Random rnd = new Random();
    //We put a +1 to make sure its in the range we want
    return rnd.Next(sides) + 1;
}

//2 Get valid dice sides
static int getDice()
{
    int numSides = 0;
    while (true)
    {
        try
        {
            numSides = int.Parse(Console.ReadLine());
            if (numSides >= 2)
            {
                break;
            }
            else
            {
                Console.WriteLine("Those kind of dice don't exist yet");
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    return numSides;
}

//3 Display combinations
static void DisplayCombo(int x, int y)
{
    //combos
    if (x == 1 && y == 1)
    {
        Console.WriteLine("Snake Eyes!");
    }
    else if ((x == 1 && y == 2) || (x ==2 && y == 1))
    {
        Console.WriteLine("Ace Deuce!");
    }
    else if (x == 6 && y == 6)
    {
        Console.WriteLine("Box Cars!");
    }

    //totals
    int total = x + y;
    if (total == 7 || total == 11)
    {
        Console.WriteLine("Win!");
    }
    else if (total == 2 || total == 3 || total == 12)
    {
        Console.WriteLine("Craps!");
    }
}

//4 continue looping
static bool GetContinue()
{
    bool loopChoice = true;
    while (true)
    {
        Console.Write("Roll again? (y/n): ");
        string result = Console.ReadLine().ToLower().Trim();
        
        if (result == "y")
        {
            loopChoice = true;
            break;
        }
        else if (result == "n")
        {
            loopChoice = false;
            break;
        }
        else
        {
            Console.WriteLine("That was not valid");
        }
    }
    return loopChoice;
}

//5 DND dice combos (rolling 2 d20)
static void DNDCombos(int x, int y)
{
    if (x == 20 && y == 20)
    {
        Console.WriteLine("SUPER SUCCESS");
    }
    else if (x == 1 && y == 1)
    {
        Console.WriteLine("SUPER FAIL");
    }
    else if (x == 20 && y >= 1)
    {
        Console.WriteLine("Normal Success");
    }
    else if (x == 1 && y <= 20)
    {
        Console.WriteLine("Normal Fail");
    }
}


