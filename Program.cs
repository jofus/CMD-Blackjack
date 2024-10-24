using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace blackjack_console_app
{

    class Program
    {
        static void Main(string[] args)
        {
            PlayBlackjack playthegame = new PlayBlackjack();
            playthegame.RunGame();

        }
    }



    // blackjack classes 
    public class PlayBlackjack
    {
        public void RunGame()
        {
            bool playGame = true;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Welcome to blackjack CMD edition!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            while (playGame)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Starting a new round!...");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dealing hand to the house...");
                Console.ForegroundColor = ConsoleColor.White;
                PlayingCards playingCardsInstance = new PlayingCards();
                Card housesCard = new Card();
                Thread.Sleep(3000);
                housesCard = playingCardsInstance.SelectingACard(0);
                Console.WriteLine("The dealers hand is showing:");
                int housesScore = 0;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(housesCard.name + " " + housesCard.suit);
                string housesCompleteCardString = housesCard.name + housesCard.suit;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                housesScore = housesCard.points;

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

                List<string> cardsDrawn = new List<string>();
                cardsDrawn.Add(housesCompleteCardString);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dealing player their first card...");
                Card playersFirst = new Card();
                Card tempCard_one = new Card();
                tempCard_one = playingCardsInstance.SelectingACard(0);
                bool invalidCard_one = true;
                string playersCompleteFirstString = tempCard_one.name + tempCard_one.suit;
                while (invalidCard_one)
                {
                    if (!cardsDrawn.Contains(playersCompleteFirstString))
                    {
                        playersFirst = tempCard_one;
                        cardsDrawn.Add(playersFirst.name + playersFirst.suit);
                        invalidCard_one = false;
                    }
                    else
                    {
                        tempCard_one = playingCardsInstance.SelectingACard(0);
                        playersCompleteFirstString = tempCard_one.name + tempCard_one.suit;
                    }
                }
                Thread.Sleep(3000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Your first card is:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(playersFirst.name + " " + playersFirst.suit);
                int playersScore = 0;
                playersScore = playersFirst.points;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dealing player their second card...");
                Card playersSecond = new Card();
                Card tempCard_two = new Card();
                tempCard_two = playingCardsInstance.SelectingACard(playersScore);
                bool invalidCard_two = true;
                string playersCompleteSecondString = tempCard_two.name + tempCard_two.suit;
                while (invalidCard_two)
                {
                    if (!cardsDrawn.Contains(playersCompleteSecondString))
                    {
                        playersSecond = tempCard_two;
                        cardsDrawn.Add(playersCompleteSecondString);
                        invalidCard_two = false;
                    }
                    else
                    {
                        tempCard_two = playingCardsInstance.SelectingACard(playersScore);
                        playersCompleteSecondString = tempCard_two.name + tempCard_two.suit;
                    }
                }
                Thread.Sleep(3000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Your second card is:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(playersSecond.name + " " + playersSecond.suit);
                playersScore = (playersScore + playersSecond.points);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Your current score is {0}", playersScore);
                Console.ForegroundColor = ConsoleColor.White;

                int numberOfAcesDrawn = 0;

                if (playersFirst.name == "Ace of" || playersSecond.name == "Ace of")
                {
                    numberOfAcesDrawn++;
                }

                bool choosing = true;
                if (playersScore == 21)
                {
                    choosing = false;
                }

                bool playerGoneBust = false;

                while (choosing)
                {
                    Console.WriteLine("Do you want to hit or stick?");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Type 'hit' to hit and 'stick' to stick...");
                    Console.ForegroundColor = ConsoleColor.White;
                    string choice = "";

                    bool validInput = false;
                    while (!validInput)
                    {
                        string nestedChoice = Console.ReadLine();

                        if (nestedChoice == "hit" || nestedChoice == "stick")
                        {
                            choice = nestedChoice;
                            validInput = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Invalid input, please eneter 'hit' or 'stick' to proceed...");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                    }

                    if (choice.ToLower() == "hit")
                    {
                        Console.WriteLine("You have chosen to hit");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Dealing player another card...");
                        Console.ForegroundColor = ConsoleColor.White;

                        Card playersExtraCard = new Card();
                        Card tempCardThree = new Card();
                        tempCardThree = playingCardsInstance.SelectingACard(playersScore);

                        bool invalidCard_three = true;
                        string playersCompleteThirdString = tempCardThree.name + tempCardThree.suit;

                        while (invalidCard_three)
                        {
                            if (!cardsDrawn.Contains(playersCompleteThirdString))
                            {
                                playersExtraCard = tempCardThree;
                                cardsDrawn.Add(playersCompleteThirdString);
                                if (playersExtraCard.name == "Ace of" && playersExtraCard.points == 11)
                                {
                                    numberOfAcesDrawn++;
                                }
                                invalidCard_three = false;
                            }
                            else
                            {
                                tempCardThree = playingCardsInstance.SelectingACard(playersScore);
                                playersCompleteThirdString = tempCardThree.name + tempCardThree.suit;
                            }
                        }
                        Thread.Sleep(3000);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Your next card is:");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(playersExtraCard.name + " " + playersExtraCard.suit);
                        playersScore = (playersScore + playersExtraCard.points);

                        if (playersScore > 21 && numberOfAcesDrawn <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Your current score is {0}", playersScore);
                            Console.WriteLine("You have gone bust!");
                            Console.ForegroundColor = ConsoleColor.White;
                            playerGoneBust = true;
                            choosing = false;
                        }
                        else if (playersScore > 21 && numberOfAcesDrawn > 0)
                        {
                            bool adjustingAces = true;

                            while (adjustingAces)
                            {
                                if (playersScore > 21 && numberOfAcesDrawn > 0)
                                {
                                    playersScore = playersScore - 10;
                                    numberOfAcesDrawn--;
                                }
                                else if (playersScore > 21 && numberOfAcesDrawn <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Your current score is {0}", playersScore);
                                    Console.WriteLine("You have gone bust!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    playerGoneBust = true;
                                    choosing = false;
                                    adjustingAces = false;
                                }
                                else if (playersScore < 21)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("Your current score is {0}", playersScore);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    adjustingAces = false;
                                }
                            }
                        }
                        else if (playersScore == 21)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Your current score is {0}", playersScore);
                            Console.ForegroundColor = ConsoleColor.White;
                            choosing = false;
                        }
                        else if (playersScore < 21)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Your current score is {0}", playersScore);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    if (choice.ToLower() == "stick")
                    {
                        Console.WriteLine("You have chosen to stick");
                        choosing = false;
                    }
                }

                if (!playerGoneBust)
                {
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Revealing house's second card...");
                    Console.ForegroundColor = ConsoleColor.White;

                    Card housesCard_two = new Card();
                    housesCard_two = playingCardsInstance.SelectingACard(housesScore);
                    string housesCompleteSecondString = housesCard_two.name + housesCard_two.suit;

                    bool invalidCard_four = true;
                    while (invalidCard_four)
                    {
                        if (!cardsDrawn.Contains(housesCompleteSecondString))
                        {
                            cardsDrawn.Add(housesCompleteSecondString);
                            invalidCard_four = false;
                        }
                        else
                        {
                            housesCard_two = playingCardsInstance.SelectingACard(housesScore);
                            housesCompleteSecondString = housesCard_two.name + housesCard_two.suit;
                        }
                    }
                    Thread.Sleep(3000);
                    Console.WriteLine("The dealers hand is showing:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(housesCard_two.name + " " + housesCard_two.suit);
                    Console.ForegroundColor = ConsoleColor.White;
                    housesScore = housesScore + housesCard_two.points;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("The house's score is {0}", housesScore);
                    Console.ForegroundColor = ConsoleColor.White;

                    Thread.Sleep(2000);
                    int houseFinalScore = Math.Abs(housesScore - 21);
                    int playersFinalScore = Math.Abs(playersScore - 21);
                    if (houseFinalScore < playersFinalScore)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The house wins!");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Would you like to play again?");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Please enter 'y' for yes and 'n' for no...");
                        Console.ForegroundColor = ConsoleColor.White;
                        bool validInput = false;
                        while (!validInput)
                        {
                            string nested_rematchChoice = Console.ReadLine();


                            if (nested_rematchChoice == "n")
                            {
                                playGame = false;
                                validInput = true;
                            }
                            else if (nested_rematchChoice == "y")
                            {
                                validInput = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Invalid input, please eneter 'y' or 'n' to proceed...");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                    else if (houseFinalScore > playersFinalScore)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You win, Congratulations!");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Would you like to play again?");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Please enter 'y' for yes and 'n' for no...");
                        Console.ForegroundColor = ConsoleColor.White;
                        bool validInput = false;
                        while (!validInput)
                        {
                            string nested_rematchChoice = Console.ReadLine();


                            if (nested_rematchChoice == "n")
                            {
                                playGame = false;
                                validInput = true;
                            }
                            else if (nested_rematchChoice == "y")
                            {
                                validInput = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Invalid input, please eneter 'y' or 'n' to proceed...");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                    else if (houseFinalScore == playersFinalScore)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("It's a draw!");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Would you like to play again?");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Please enter 'y' for yes and 'n' for no...");
                        Console.ForegroundColor = ConsoleColor.White;
                        bool validInput = false;
                        while (!validInput)
                        {
                            string nested_rematchChoice = Console.ReadLine();


                            if (nested_rematchChoice == "n")
                            {
                                playGame = false;
                                validInput = true;
                            }
                            else if (nested_rematchChoice == "y")
                            {
                                validInput = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Invalid input, please eneter 'y' or 'n' to proceed...");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                }
                else if (playerGoneBust)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Would you like to play again?");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Please enter 'y' for yes and 'n' for no...");
                    Console.ForegroundColor = ConsoleColor.White;
                    bool validInput = false;
                    while (!validInput)
                    {
                        string nested_rematchChoice = Console.ReadLine();


                        if (nested_rematchChoice == "n")
                        {
                            playGame = false;
                            validInput = true;
                        }
                        else if (nested_rematchChoice == "y")
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Invalid input, please eneter 'y' or 'n' to proceed...");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
    }

    public class Card
    {
        public string suit = "";
        public string name = "";
        public int points = 0;
    }

    public class PlayingCards
    {
        public string[] cardClass = { "clubs", "spades", "hearts", "diamonds" };
        public string[] cardName = { "Ace of", "Two of", "Three of", "Four of", "Five of", "Six of", "Seven of", "Eight of", "Nine of", "Ten of", "Jack of", "Queen of", "King of" };

        public Card SelectingACard(int sumOfCardVals)
        {

            Random _random = new Random();

            int rdm_Class = _random.Next(0, 3);
            string chosenClass = cardClass[rdm_Class];

            int rdm_Name = _random.Next(0, 12);
            string chosenName = cardName[rdm_Name];

            int chosenVals = 0;

            switch (chosenName)
            {
                case "Ace of":
                    if (sumOfCardVals >= 11)
                    {
                        chosenVals = 1;
                    }
                    else
                    {
                        chosenVals = 11;
                    }
                    break;

                case "Two of":
                    chosenVals = 2;
                    break;

                case "Three of":
                    chosenVals = 3;
                    break;

                case "Four of":
                    chosenVals = 4;
                    break;

                case "Five of":
                    chosenVals = 5;
                    break;

                case "Six of":
                    chosenVals = 6;
                    break;

                case "Seven of":
                    chosenVals = 7;
                    break;

                case "Eight of":
                    chosenVals = 8;
                    break;

                case "Nine of":
                    chosenVals = 9;
                    break;

                case "Ten of":
                    chosenVals = 10;
                    break;

                case "Jack of":
                    chosenVals = 10;
                    break;

                case "Queen of":
                    chosenVals = 10;
                    break;

                case "King of":
                    chosenVals = 10;
                    break;

                default:
                    Console.WriteLine("something went wrong in the switch case");
                    chosenVals = 0;
                    break;
            }
            Card chosenCard = new Card();
            chosenCard.name = chosenName;
            chosenCard.suit = chosenClass;
            chosenCard.points = chosenVals;
            return chosenCard;
        }
    }
}
