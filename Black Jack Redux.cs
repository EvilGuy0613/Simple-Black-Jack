using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Net.Http.Headers;
using System;
using System.Formats.Asn1;

namespace Program
{
    class Program
    {
        static Random Cards=new Random();

        static int Player = 0; // The Player score starting a 0 because we haven't drawned any cards yet. 
        static int Dealer = 0; // The Dealaer score starting a 0 because we haven't drawned any cards yet. (Dealer hasn't been redone yet)
        static string RandomValue; //Variable used to display our Card Values
        static string SuitResult; //Variable used to display our Suits 
        static int AceTotal = 0; //Ace starts at 0. The Player or Dealer will declare if Ace becomes 11 or 1

        static string[] Suits = {"Hearts", "Diamonds", "Clubs", "Spades"};  // Variable that is used for the suit of the card. 

        static string[] Value = {"2", "3", "4", "5", "6", "7", "8", "9", "Jack", "Queen", "King", "Ace"};
        // Variablue that is used for the number value of the cards.

        static Dictionary<string, int> ValueToNumber = new Dictionary<string, int>()
    {
        {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"Jack", 10}, {"Queen", 10}, {"King", 10}, {"Ace", 0}, 
    };
    // Maps the card values to an actual number value. 

        static void Main(string[] args) //CODE STARTS HERE! (This is for my own reference)
        {

            for(int i = 1; i < 3; i++) //Player draws two cards from the deck to start off the game. (The Code will loop twice to indicate that)
            {
                RandomCardValue(); //Draws a Card
                PlayerValue (); //Adds that Card Value to Player's total score 
                DisplayCard(); //Displays the Player's Card 
                if (RandomValue == "Ace") //If Player card is an Ace, they'll have to determine if Ace is 1 or 11
                {
                    DrawAce(); 
                }
            }
           
            PlayerScore();           

                for (int i = 3; Player <= 21; i++) //After the first two cards, Player decides if they want to draw more cards
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Hit or Stay?");
                    string Draw = Console.ReadLine().Trim();
                    
                    if(Draw == "Hit") //Player Draws another card
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You choose to hit!");
                        Console.ReadKey();

                        RandomCardValue();
                        PlayerValue (); 
                        DisplayCard();     
                        PlayerScore(); 
                    }

                    else if (Draw == "Stay") //Player doesn't draw and current total is final
                    {
                        Console.WriteLine("You sustained.");
                        Console.ReadKey();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Your final score is "+Player);
                        Console.ReadKey();
                        break;
                    }   
                    else //Repeats the code because input wasn't vaild. Our only vaild inputs here or Hit or Stay 
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("This is not a vaild input. Please try again!"); 
                    }
                }
            GameResults();
        } //End of Main Code
        static void RandomCardValue() //Code that determines what our Card and Suit value will be
        {
            int RandomCard = Cards.Next(0, Value.Length); // Variable that will choose a random element within Value based on the index number
            RandomValue = Value[RandomCard]; // Variable that will display the random element that was choosen within Value 
            
            int RandomSuit = Cards.Next(Suits.Length); // Variable that will choose a random element within Suits based on the index number
            SuitResult = Suits[RandomSuit]; //A Variable that will display the random element that is choosen within the Value 
        }
        static void PlayerValue() //Code that will increase the total of the Player based on the card value that's drawn and the number mapped to it
        {
            Player += ValueToNumber[RandomValue]; 
        }

        static void DisplayCard() //Code that'll display which card value and suit was drawn by the Player
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player drew a {RandomValue} of {SuitResult}"); 
            Console.ReadKey();
        }
        static void PlayerScore() //Code that displays the Player's current total 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your score is "+Player);
            Console.ReadKey();
        }
        static void DrawAce() //Code that handles the result of drawing an Ace
        {
            bool Valid = false;
            
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

                else //Repeats the code because input wasn't vaild. Our only vaild inputs are 1 and 11
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("This is not a vaild input. Please try again!"); 
                }
            }
        }
        static void GameResults() //Code that handles the ending results of the game
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
            }     
        }
    } //End of Class Program 
}  //End of Name space 
