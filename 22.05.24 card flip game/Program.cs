using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CardPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int Player1score = 0;
            int Player2score = 0;
            bool Player1Turn = true;
            int NoCardsOnTable = 54;
            Card[,] cardsOntable = new Card[6, 9]; //2D ARRAY OF THE CARS ON THE SCREEN.
            Deck d = new Deck(true, ConsoleColor.DarkBlue); // MAKE A PACK WITH JOKERS
            d.Shuffle(); //sHUFFLE IT
            createTable(d, cardsOntable);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); //NEED A BIG CONSOLE

            //display the cards on table


            //game Time!
            while (NoCardsOnTable > 0)
            {
                //choose a card
                DisplayCardsOnTable(cardsOntable, d.DeckColour);
                Console.SetCursorPosition(0, 38);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPAIRS! A test of memory\n");
                Console.ForegroundColor = ConsoleColor.White;
                

                if (Player1Turn)
                { Console.WriteLine($"Player 1 score = ({Player1score})"); }
                else
                { Console.WriteLine($"Player 2 score = ({Player2score})"); }

                Console.Write("\nEnter col (0-8) : ");
                int rs1 = int.Parse(Console.ReadLine());
                Console.Write("Enter row (0-5) : ");
                int cs1 = int.Parse(Console.ReadLine());
                
                Card Firstcardselected = cardsOntable[cs1, rs1]; //FIND CARD AT THAT LOCATION
                                                                 //TURN IT OVER
                Firstcardselected.Flip();
                DisplayCardsOnTable(cardsOntable, d.DeckColour);
                //choose another card
                Console.Write("Enter col : ");
                int rs2 = int.Parse(Console.ReadLine());
                Console.Write("Enter row : ");
                int cs2 = int.Parse(Console.ReadLine());
                Card Secondcardselected = cardsOntable[cs2, rs2];
                
                
                Secondcardselected.Flip();
                DisplayCardsOnTable(cardsOntable, d.DeckColour);
                // if both cards value equal thats a pair!
                // the player scores a point
                // the two cards are removed from the table
                // reduce the variable NocardsOntable by 2
                // the player gets to choose another two cards
                if (Firstcardselected.Value == Secondcardselected.Value)
                {
                    Console.WriteLine("Thats a pair!");
                    System.Threading.Thread.Sleep(2000);
                    if (Player1Turn) { Player1score++; }
                    if (!Player1Turn) { Player2score++; }
                    cardsOntable[cs1, rs1] = null;
                    cardsOntable[cs2, rs2] = null;
                    NoCardsOnTable -= 2;
                    
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    Player1Turn = !Player1Turn;
                    Firstcardselected.Flip();
                    Secondcardselected.Flip();
                    DisplayCardsOnTable(cardsOntable, d.DeckColour);
                }
                //if the two cards are not equal
                // flip the cards back over.
                // swap the player turn
                if (NoCardsOnTable <= 0)
                {
                    Console.WriteLine("Game Over!");
                    return;
                }
                //keep playing until no more cards left!
            }

        }

        static void DisplayCardsOnTable(Card[,] tableCards, ConsoleColor back)
        {
            Console.Clear();
            for (int tr = 0; tr < 9; tr++)
            {
                Console.SetCursorPosition(tr * 7 + 5, 0);
                Console.Write(tr);
            }

            for (int col = 0; col < 6; col++)
            {

                Console.SetCursorPosition(1, col * 6 + 4);
                Console.Write(col);
                for (int row = 0; row < 9; row++)
                {

                    Card c = tableCards[col, row];
                    if (c != null) { c.Display(row * 7 + 3, col * 6 + 2, back); }
                }
            }
        }

        static void createTable(Deck d, Card[,] tableCards)
        {
            for (int col = 0; col < 6; col++)
            {
                for (int row = 0; row < 9; row++)
                {
                    Card c = d.DrawCard();
                    tableCards[col, row] = c;
                }
            }
        }
    }
}