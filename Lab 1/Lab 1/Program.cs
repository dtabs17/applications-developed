using System.Globalization;
using System.Text;

//variables in the message encoder
int option, wordCount, wordlength, combinedLength;
string message = null, encodedMessage, key1 = null, encodedMessage1 = null;
char randomsymbol, mostFrequentLetter;
int asciicode, highestFrequency, highestFrequency1;
wordCount = 0;


//variables in the message decoder
int option1, option2;

//variables for the Rock Paper Scissors Lizard Spock game
string Computerchoice = null, UserChoice = null;
bool? Results;
int randomIndex, option3, UserScore = 0, ComputerScore = 0;

do
{
    Console.WriteLine("Option 1: Message Encoder.");
    Console.WriteLine("Option 2: Message Decoder.");
    Console.WriteLine("Option 3: Rock! Paper! Scissors! Lizard! Spock!.");
    Console.WriteLine("Option 4: Exit.");
    option1 = Convert.ToInt32(Console.ReadLine());
    switch (option1)
    {
        case 1:
            do
            {
                Console.WriteLine("Option 1: Enter message to encode.");
                Console.WriteLine("Option 2: Display encoded message and key.");
                Console.WriteLine("Option 3: Exit.");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nPlease enter the message you want to encode:");
                        message = Console.ReadLine();
                        break;

                    case 2:
                        if (message == "" || message == " ")
                        {
                            Console.WriteLine("\nYou do not have a message, please enter a message in option 1");
                        }
                        else
                        {
                            string[] words = message.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                            wordCount = words.Length;


                            randomsymbol = randomSymbol();
                            asciicode = (int)randomsymbol;
                            highestFrequency = GetMostFrequentLetter(message, out mostFrequentLetter);


                            StringBuilder outputBuilder = new StringBuilder();

                            // encoding the message

                            encodedMessage = message;
                            string[] words1 = encodedMessage.Split(' ');

                            // Reverse each word and join them back

                            encodedMessage = string.Join(" ", words1.Select(word => new string(word.Reverse().ToArray())));
                            encodedMessage = encodedMessage.Replace(" ", "");

                            for (int i = 0; i < wordCount; i++)
                            {
                                string word = words[i];
                                wordlength = word.Length;
                                combinedLength = wordlength + highestFrequency;

                                outputBuilder.Append($"{combinedLength}:");
                            }
                            Console.WriteLine("\n");
                            string key = $"{wordCount}-{asciicode}/{outputBuilder}";

                            key = MoveDigits(key);

                            //Console.WriteLine($"The key before reversing it is: {key}");

                            char[] charArray = key.ToCharArray();
                            Array.Reverse(charArray);
                            key = new string(charArray);
                            Console.WriteLine($"The encoded message is: {encodedMessage} and the key is: {key}");
                            Console.WriteLine("\n");
                        }
                        break;

                    case 3:
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid option from 1-3");
                        break;
                }
            }
            while (option != 3);
            Console.WriteLine("\nThank you for using the message encoder");

            break;

        case 2:
            do
            {
                Console.WriteLine("Option 1: Enter encoded message and key to decode.");
                Console.WriteLine("Option 2: Display decoded message.");
                Console.WriteLine("Option 3: Exit.");
                option2 = Convert.ToInt32(Console.ReadLine());
                switch (option2)
                {
                    case 1:
                        Console.WriteLine("Enter encoded message: ");
                        encodedMessage1 = Console.ReadLine();

                        Console.WriteLine("Enter key: ");
                        key1 = Console.ReadLine();

                        break;

                    case 2:
                        char[] charArray1 = key1.ToCharArray();
                        Array.Reverse(charArray1);

                        key1 = new string(charArray1);
                        // Console.WriteLine($"The key is now: {key1}");
                        key1 = MoveDigits2(key1);
                        // Console.WriteLine($"The key is now: {key1}");

                        string[] parts = key1.Split(':', '/');

                        // Remove empty entries from the parts array

                        parts = parts.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                        string[] splitPositions = new string[parts.Length - 1];
                        Array.Copy(parts, 1, splitPositions, 0, parts.Length - 1);



                        int[] intKey1 = new int[splitPositions.Length];
                        for (int i = 0; i < splitPositions.Length; i++)
                        {
                            intKey1[i] = int.Parse(splitPositions[i]);
                        }


                        highestFrequency1 = GetMostFrequentLetter(encodedMessage1, out mostFrequentLetter);
                        // Console.WriteLine($"This is the highest freq {highestFrequency1}");

                        for (int i = 0; i < intKey1.Length; i++)
                        {
                            intKey1[i] -= highestFrequency1;
                        }



                        string[] results2 = new string[intKey1.Length];
                        for (int i = 0; i < intKey1.Length; i++)
                        {
                            string[] results1 = SplitString(ref encodedMessage1, intKey1[i]);
                            results2[i] = results1[0];
                        }


                        Console.WriteLine("\n");
                        encodedMessage1 = string.Join(" ", results2.Select(word => new string(word.Reverse().ToArray())));
                        Console.WriteLine($"The decoded message is: {encodedMessage1}");
                        break;
                    case 3:
                        break;
                }
            }
            while (option2 != 3);
            break;

        case 3:

            do
            {
                Console.WriteLine("Option 1: Start new game.");
                Console.WriteLine("Option 2: Computer's go.");
                Console.WriteLine("Option 3: User's go.");
                Console.WriteLine("Option 4: Display winner.");
                Console.WriteLine("Option 5: Display scores.");
                Console.WriteLine("Option 6: Exit.");
                option3=Convert.ToInt32(Console.ReadLine());
                
                switch (option3)
                {
                    case 1:
                        Console.WriteLine("A new game has started!");
                        ComputerScore = 0; 
                        UserScore = 0;
                        break;
                    case 2:
                        string[] choice = { "Rock", "Paper", "Scissors", "Lizard", "Spock", };
                        Random random = new Random();
                        randomIndex = random.Next(choice.Length);
                        Computerchoice = choice[randomIndex];
                        Console.WriteLine("The computer has selected a state.");
                        break;
                    case 3:
                        Console.WriteLine("Please select a state between the following: Rock, Paper, Scissors, Lizard, Spock");
                        UserChoice = Console.ReadLine();
                        Console.WriteLine();
                        break;
                    case 4:
                        Results = DidTheComputerWin(Computerchoice, UserChoice);
                        if (Results == true)
                        {
                            Console.WriteLine($"You chose: {UserChoice} and the computer chose: {Computerchoice}, so the Computer wins!");
                            ComputerScore++;
                        }
                        else if (Results == false)
                        {
                            Console.WriteLine($"You chose: {UserChoice} and the computer chose: {Computerchoice}, so you win!");
                            UserScore++;
                        }
                        else
                        {
                            Console.WriteLine($"You and the computer chose: {Computerchoice} so it's a tie!");
                        }
                        Console.WriteLine();    
                        break;
                    case 5:
                        Console.WriteLine($"Your score is {UserScore} and the computer's score is {ComputerScore}");
                        break;
                    case 6:
                        break;
                }

                
            }
            while (option3 != 6);
            Console.WriteLine("Thank you for playing the game!");
            break;

        case 4:
            break;
        default:
            Console.WriteLine("\nPlease enter a valid option from 1-4");
            break;
    }


}
while (option1 != 4);
Console.WriteLine("Goodbye!");

//function to calculate the the heightest frequency of any individual letter in the message
static int GetMostFrequentLetter(string input, out char mostFrequentLetter)
{
    mostFrequentLetter = '\0';
    int[] letterCounts = new int[26];

    int maxCount = 0;
    foreach (char letter in input)
    {
        if (Char.IsLetter(letter))
        {
            char lowercaseLetter = Char.ToLower(letter);
            int index = lowercaseLetter - 'a';
            letterCounts[index]++;

            if (letterCounts[index] > maxCount)
            {
                maxCount = letterCounts[index];
                mostFrequentLetter = lowercaseLetter;
            }
        }
    }
    return maxCount;
}

//function to pick a random symbol from the 6 symbols listed
static char randomSymbol()
{
    char randomSymbol;
    int randomIndex;
    char[] symbols = { '!', '*', '@', '?', '^', ':' };
    Random random = new Random();
    randomIndex = random.Next(symbols.Length);
    randomSymbol = symbols[randomIndex];
    return randomSymbol;
}


// function to move the characters at position 4 & 5 to positions 1 & 2
static string MoveDigits(string message)
{
    char char4, char5;
    char4 = message[3];
    char5 = message[4];
    message = message.Remove(3, 2);
    message = char4.ToString() + char5.ToString() + message;
    return message;
}



static string MoveDigits2(string message)
{
    string firstTwoChars = message.Substring(0, 2);

    // Remove the first two characters from the input string
    message = message.Remove(0, 2);

    // Insert the firstTwoChars at positions 4 and 5
    message = message.Insert(3, firstTwoChars);
    return message;
}



static string[] SplitString(ref string input, int position)
{
    if (position < 0 || position > input.Length)
    {
        throw new ArgumentOutOfRangeException("position", "Position is out of range.");
    }

    string[] result = new string[2];
    result[0] = input.Substring(0, position);
    result[1] = input.Substring(position);

    input = result[1];
    return result;
}


static Boolean? DidTheComputerWin(string computersState, string usersState)
{
    Boolean? ComputerWin = false;
    
    if (computersState.Equals(usersState)) 
    { 
        ComputerWin = null; 
    }
    else
    {
        switch (computersState)
        {
            case "Rock":
                if (usersState.Equals("Lizard") || usersState.Equals("Scissors"))
                {
                    ComputerWin = true;
                }
                break;
            case "Paper":
                if (usersState.Equals("Rock") || usersState.Equals("Spock"))
                {
                    ComputerWin = true;
                }
                break;
            case "Scissors":
                if (usersState.Equals("Paper") || usersState.Equals("Lizard"))
                {
                    ComputerWin = true;
                }
                break;
            case "Lizard":
                if (usersState.Equals("Paper") || usersState.Equals("Spock"))
                {
                    ComputerWin = true;
                }
                break;
            case "Spock":
                if (usersState.Equals("Rock") || usersState.Equals("Scissors"))
                {
                    ComputerWin = true;
                }
                break;
        }
    }

    return ComputerWin;
}
