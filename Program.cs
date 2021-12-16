using System;

/* BOSS BATTLE: The Point */


//Point point1 = new Point(2, 3);
//Point point2 = new Point(-4, 0);

// point1.printPoint();
// point2.printPoint();

/* BOSS BATTLE: The Color */

//Color white = Color.White;
//Color odGreen = new Color(0, 102, 0);


/* BOSS BATTLE: The Card */

//Card[] RedCards = new Card[14];
//Card[] GreenCards = new Card[14];
//Card[] BlueCards = new Card[14];
//Card[] YellowCards = new Card[14];


// white.printColor();
// odGreen.printColor();




//for (int i = 0; i < 14; i++)
//{
//    Card redCard = new Card(CardColor.red, (CardRank)i);
//    RedCards[i] = redCard;

//    Card greenCard = new Card(CardColor.green, (CardRank)i);
//    GreenCards[i] = greenCard;

//    Card blueCard = new Card(CardColor.blue, (CardRank)i);
//    BlueCards[i] = blueCard;

//    Card yellowCard = new Card(CardColor.yellow, (CardRank)i);
//    YellowCards[i] = yellowCard;

//}

//foreach (Card card in RedCards)
//{
//    card.printCard();
//}

//foreach (Card card in GreenCards)
//{
//    card.printCard();
//}

//foreach (Card card in BlueCards)
//{
//    card.printCard();
//}

//foreach (Card card in YellowCards)
//{
//    card.printCard();
//}

/* BOSS BATTLE: The Locked Door */

//string message = "Enter an initial passcode:";
//int passCode = printMessage(message);

//Door door = new Door(DoorState.closed, passCode, false, true);
//int choice;

//do
//{

//    //Console.Clear();

//    Console.BackgroundColor = ConsoleColor.Green;
//    Console.ForegroundColor = ConsoleColor.Black;

//    door.printDoorState();

//    Console.ForegroundColor = ConsoleColor.White;
//    Console.BackgroundColor = ConsoleColor.Black;

//    string userMenu = "Choose an option from the list: \n" +
//    "1 = open door, 2 = close door, 3 = lock door, 4 = unlock door, 5 = change passcode, 99 = exit: ";

//    choice = printMessage(userMenu);

//    Console.ForegroundColor = ConsoleColor.Green;
//    Console.BackgroundColor = ConsoleColor.Black;

//    switch (choice)
//    {
//        case 1:
//            door.openDoor();
//            break;
//        case 2:
//            door.closeDoor();
//            break;
//        case 3:
//            door.lockDoor();
//            break;
//        case 4:
//            door.unlockDoor();
//            break;
//        case 5:
//            door.setLockCode();
//            break;
//        case 99:
//            break;
//        default:
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.WriteLine("Enter a value between 1 and 5.");
//            Console.ForegroundColor = ConsoleColor.White;
//            break;
//    }

//    Console.ForegroundColor = ConsoleColor.White;

//} while (choice != 99);

/* BOSS BATTLE: The Password Validator*/


Console.WriteLine("*********************************************\n" +
"Password must be 6 to 13 charactes in length,\n" +
"and must contain:\n" +
    "- 1 Number\n" +
    "- 1 Uppercase Letter\n" +
    "- 1 Lowercase Letter\n" +
"*********************************************");


while (true)
{
string password = getPassword();

PasswordValidator myPassword = new PasswordValidator(password);
}


/*************** Functions ****************/

int printMessage(string message)
{
    Console.Write($"{message} ");
    string input = Console.ReadLine();
    int choice = Convert.ToInt32(input);

    Console.WriteLine($"You chose {choice}.");

    return choice;
}

string getPassword()
{
    Console.Write($"Enter a password: ");
    string input = Console.ReadLine();
    return input;
}


/*************** CLASSES ****************/

//CLASS: PasswordValidator
public class PasswordValidator
{
    public string Password { get; set; }
    public bool PasswordIsValid { get; set; }
    private string _default = "!QAZ@WSX1qaz2";

    public PasswordValidator()
    {
        Password = _default;
        PasswordIsValid = true;
    }

    public PasswordValidator(string password)
    {
        Console.WriteLine(validatePassword(password));
    }

    ~PasswordValidator()
    {

    }

    public string validatePassword(string password)
    {
        int upperCaseLetters = 0;
        int lowerCaseLetters = 0;
        int numbers = 0;
        int totalCharacters = 0;
        string message;

        foreach (char value in password)
        {
            totalCharacters++;
            if (value == 'T' || value == '&')
            {
                PasswordIsValid = false;
                message = $"Password cannot contain a '{value}'.";
                return message;
            }
            if (char.IsUpper(value)) upperCaseLetters++;
            if (char.IsLower(value)) lowerCaseLetters++;
            if (char.IsNumber(value)) numbers++;
        }

        if (!(totalCharacters >= 6 && totalCharacters <= 13))
        {
            PasswordIsValid = false;
            Password = _default;
            message = $"Password length is {totalCharacters}. Password must be between 6 and 13 characters.";
        }
        else if (upperCaseLetters == 0)
        {
            PasswordIsValid = false;
            Password = _default;
            message = "Password must contain at least 1 uppercase letter.";
        }
        else if (lowerCaseLetters == 0)
        {
            PasswordIsValid = false;
            Password = _default;
            message = "Password must contain at least 1 lowercase letter.";
        }
        else if (numbers == 0)
        {
            PasswordIsValid = false;
            Password = _default;
            message = "Password must contain at least 1 number.";
        }
        else
        {
            PasswordIsValid = true;
            Password = password;
            message = $"{password } is {totalCharacters} charactesr, contains {upperCaseLetters}" +
                $" uppercase letters, {lowerCaseLetters} lower case letters, and {numbers} numbers.\n" +
                $"{password} is a valid password.";
        }
        
        return message;
    }


}
// CLASS: Door
public class Door
{
    public DoorState State { get; set; }
    public int LockCode { get; set; }
    public bool IsOpen { get; set; }
    public bool IsLocked { get; set; }

    public Door()
    {
        State = DoorState.open;
        LockCode = 12345;
        IsOpen = true;
        IsLocked = false;
    }

    public Door(DoorState state, int lockCode, bool isOpen, bool isLocked)
    {
        State = state;
        LockCode = lockCode;
        IsOpen = isOpen;
        IsLocked = isLocked;
    }

    ~Door()
    {

    }

    public void openDoor()
    {
        if (!IsOpen && !IsLocked)
        {
            State = DoorState.open;
            IsOpen = true;
        }
        else if (IsLocked)
        {
            unlockDoor();
            return;
        }

        // printDoorState();
    }
    public void closeDoor()
    {
        if (IsOpen == true)
        {
            State = DoorState.closed;
            IsOpen = false;
        }

        // printDoorState();
    }
    public void lockDoor()
    {
        if (!IsOpen && !IsLocked)
        {
            State = DoorState.locked;
            IsLocked = true;
        }

        // printDoorState();
    }
    public void unlockDoor()
    {
        if (IsLocked)
        {
            printDoorState();
            if (getLockCode() == true)
            {
                State = DoorState.unlocked;
                IsLocked = false;
                // printDoorState();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The door is already unlocked.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public void printDoorState()
    {
        Console.WriteLine($"The door is {State}.");
    }

    public bool getLockCode()
    {
        int lockCode = 0;
        int attempt = 1;
        string message = "Enter numeric passcode:";
        while (attempt <= 3)
        {
            lockCode = printMessage(message);
            if (lockCode != LockCode)
            {
                attempt++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Passcode is incorrect. Please try again. (Attempt {attempt} of 3)");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                return true;
            }
        }

        return false;

    }
    public void setLockCode()
    {
        if (getLockCode() == true)
        {
            string message = "Enter new passcode: ";
            int newCode = printMessage(message);
            LockCode = newCode;
            Console.WriteLine("Passcode change successful.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: Passcode change failed");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    private int printMessage(string message)
    {
        Console.Write($"{message} ");
        int choice = Convert.ToInt32(Console.ReadLine());

        return choice;
    }

}


// CLASS: Color
public class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public static Color White = new Color(255, 255, 255);
    public static Color Black = new Color(0, 0, 0);
    public static Color Red = new Color(255, 0, 0);
    public static Color Orange = new Color(255, 156, 0);
    public static Color Yellow = new Color(255, 255, 0);
    public static Color Green = new Color(0, 128, 0);
    public static Color Blue = new Color(0, 0, 255);
    public static Color Purple = new Color(128, 0, 128);


    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }
    public Color()
    {
        R = 0;
        G = 128;
        B = 0;
    }

    public void printColor()
    {
        Console.WriteLine($"(R={R}, G={G}, B={B})");
    }
}

// CLASS: Card
public class Card
{
    public CardColor Color { get; }
    public CardRank Rank { get; }

    public bool isFaceCard => Rank == CardRank.dollarSign ||
        Rank == CardRank.percentSign ||
        Rank == CardRank.carrot ||
        Rank == CardRank.ampersand;

    public Card()
    {
        Color = CardColor.red;
        Rank = CardRank.five;
    }

    public Card(CardColor color, CardRank rank)
    {
        Color = color;
        Rank = rank;
    }

    public void printCard()
    {
        Console.WriteLine($"The {Color} {Rank}");
    }


}

// CLASS: Point
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point()
    {
        X = 0;
        Y = 0;
    }

    public void printPoint()
    {
        Console.WriteLine($"({X}, {Y})");
    }

}

public enum CardColor { red, green, blue, yellow }
public enum TextColor { red, green, blue, yellow }
public enum CardRank { one, two, three, four, five, six, seven, eight, nine, ten, dollarSign, percentSign, carrot, ampersand }
public enum DoorState { open, closed, locked, unlocked }

/* BOSS BATTLE: The Chamber of Design */
/* BOSS BATTLE: Rock-Paper-Scissors */
/* BOSS BATTLE: 15-Puzzle*/
/* BOSS BATTLE: Hangman */
/* BOSS BATTLE: Tic-Tac-Toe*/