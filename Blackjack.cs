using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Net.Http.Headers;

Random Cards=new Random();


int Player = 0; // The player score starting a 0 because we haven't drawned any cards yet. 
int Dealer = 0; // The dealaer score starting a 0 because we haven't drawned any cards yet. 

string[] Suits = {"Hearts", "Diamonds", "Clubs", "Spades"}; 
// Variable that is used for the suit of the card. 

string[] Value = {"2", "3", "4", "5", "6", "7", "8", "9", "Jack", "Queen", "King", "Ace"};
// Variablue that is used for the number value of the cards.

Dictionary<string, int> ValueToNumber = new Dictionary<string, int>()
  {
{"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"Jack", 10}, {"Queen", 10}, {"King", 10}, {"Ace", 0}, 
 };
// Maps the card values to an actual number value. 


for(int i = 1; i < 3; i++) 
//Player draws two cards from the deck to start off the game. (The Code will loop twice to indicate that)

{
int RandomCard = Cards.Next(0, Value.Length);
// Variable that will choose a random element within Value based on the index number

string RandomValue = Value[RandomCard];
// Variable that will display the random element that was choosen within Value 

Player += ValueToNumber[RandomValue];
//Adds to the player's score based on the chosen element and the number mapped to it

int RandomSuit = Cards.Next(Suits.Length);
// Variable that will choose a random element within Suits based on the index number

string SuitResult = Suits[RandomSuit];
//A Variable that will display the random element that is choosen within the Value 

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Your Card {i} is a {RandomValue} of {SuitResult}");
Console.ReadKey();
//Shows both the Card and Suits Player drew 

    if (RandomCard == 11)  //If Ace is your card, prompt the player to choose a total between 1 or 11
 
    {
    
    bool Valid = false;
    int AceTotal = 0;
    
        while(!Valid) //Loops the code until your input is 1 or 11
        {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Will our Ace be 1 or 11?");
        string Ace = Console.ReadLine().Trim(); //Prevents empty spaces which will prevent errors when we press enter.

            if (Ace == "1"|| Ace == "11") //If input is 1 or 11 add one of the totals to the player's score.
            {
            AceTotal = int.Parse(Ace); //Converts your text input into a Integer
            Player += AceTotal; //Adds either 1 or 11 to the player score depending on the input
            Valid = true; //Will break the loop because Valid is no longer false.
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Ace became a " +Ace+ "!");
            Console.ReadKey();
            }

           else 
           {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("This is not a vaild input. Please try again!"); //Repeats the code because input wasn't vaild. Our only vaild inputs are 1 and 11
           }
        } 
    }
}

//Dealer's Turn. The process is the same except we're adding to the Dealer's max total instead.
for(int i = 1; i < 3; i++) 
{

int RandomCard = Cards.Next(0, Value.Length);
string RandomValue = Value[RandomCard];
Dealer += ValueToNumber[RandomValue];
int RandomSuit = Cards.Next(Suits.Length);
string SuitResult = Suits[RandomSuit];
 
    
Console.ForegroundColor = ConsoleColor.Blue;
if (i == 2) //On the second loop the Dealer's second card will be face down and unknown to the player.
{
Console.WriteLine($"Dealer's Card {i} is face down.");
Console.ReadKey(); 
}
else // On the first loop the Dealer's first Card is revealed to the player
{
Console.WriteLine($"Dealer's Card {i} is a {RandomValue} of {SuitResult}");
Console.ReadKey();
}
if 
(RandomCard == 11) //If the Dealer pulls an Ace, they have a 50% to choose 1 or 11 as their Ace Value. 
{
        int DealerAce = Cards.Next(0,2);

        if (DealerAce == 0)
        {
        Dealer += 1;
        }
        else if (DealerAce == 1)
       {
        Dealer += 11; 
        }




}
}


Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Your score is "+Player);
Console.ReadKey();


for (int i = 3; Player <= 21; i++) //After the first two cards, Player decides if they want to draw more cards
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Hit or Stay?");
    string Draw = Console.ReadLine().Trim();

    if (Draw == "Hit") //draws another card
 
    {
    
    int RandomCard = Cards.Next(0, Value.Length);
    string RandomValue = Value[RandomCard];
    Player += ValueToNumber[RandomValue];
    int RandomSuit = Cards.Next(Suits.Length);
    string SuitResult = Suits[RandomSuit];
    
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("You choose to hit!");
    Console.ReadKey();
    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Your Card {i} is a {RandomValue} of {SuitResult}");
    Console.ReadKey();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Your score is "+Player);
    Console.ReadKey();


    }
    
    else if (Draw == "Stay") //doesn't draw a card and sticks with thier current value. 
    {
    Console.WriteLine("You sustained.");
    Console.ReadKey();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Your final score is "+Player);
    Console.ReadKey();
    break;
    }

    


    else 
    {
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("This is not a vaild input. Please try again!"); //Repeats the code because input wasn't vaild. Our only vaild inputs are 1 and 11
    }

}

// Dealer Turn to decide to Hit or Stay
    
    for (int i = 3; ; i++)
{
        if (Player >  21) //if Player's value exceeds over 21, the game stops here and the Dealer Wins
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You busted! The Dealer wins!");
        Console.ReadKey();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Final score!");
        Console.WriteLine(Player);
        Console.WriteLine(Dealer);
        Console.ReadKey();

        break;
        }
        else if (Dealer > 21) //if Dealer's value exceeds over 21, the game stops here and the Player wins
        {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("The Dealer busted! You win!");
        Console.ReadKey();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Final score!");
        Console.WriteLine(Player);
        Console.WriteLine(Dealer);
        Console.ReadKey();
        break;
        }
        else if (Dealer < 17) //If Dealer value is less than 17, they are forced to hit  
        {

        int RandomCard = Cards.Next(0, Value.Length);
        string RandomValue = Value[RandomCard];
        Dealer += ValueToNumber[RandomValue];
        int RandomSuit = Cards.Next(Suits.Length);
        string SuitResult = Suits[RandomSuit];
    
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The Dealer Hit!");
        Console.ReadKey();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Dealer's Card {i} is a {RandomValue} of {SuitResult}");
        Console.ReadKey();

            if (RandomCard == 11) //Dealer's third card is an Ace
            {
                if (Dealer <= 10) //If Dealer's value is 10 or less, Ace value will be 11 as they aren't in risk of busting
                {
                Dealer +=11;
                }

                else if (Dealer > 10) //If Dealer's value is over 10, Ace value will be 1 as they'll auto bust if they make Ace 11
                {
                Dealer +=1;
                }
            

            }
        }
        
        else //Dealer will no longer hit if their value is at least 17
        {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The Dealer sustained!");
        Console.ReadKey();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The Dealer's final score is " +Dealer+ ".");
        Console.ReadKey();
        
            if (Player >  Dealer) //Player wins value is higher than Dealer without busting 
            {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You win!");
            Console.ReadKey();
            break;
            }

            else if (Player < Dealer) //Dealer wins value is higher than Player without busting 
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lose!");
            Console.ReadKey();
            break;
            }


            else if (Player == Dealer)//If both Player and Dealer's value = each other, nobody wins
            {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("It's a draw...");
            Console.ReadKey();
            break;
            }
        }
}



    