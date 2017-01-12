using System;
// using Cards if you wanted card to have namespace card

namespace DeckOfCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Would you like to play BlackJack? (y/n) ;)");
            string answer = Console.ReadLine();
            if (answer == "n"){
                System.Console.WriteLine("K bye :(");
            }
            else {
                //make player and dealer
                System.Console.WriteLine("Welcome to Casino Dojo, I'll be your host, Jack.  \nWhat is your name?");
                string name = Console.ReadLine();
                Player player1 = new Player(name);
                Player dealer = new Player("Jack");
                
                //make deck and shuffle it
                Deck deck = new Deck();
                deck.shuffle();

                //draw hands
                player1.Draw(deck); 
                player1.Draw(deck);
                dealer.Draw(deck);
                dealer.Draw(deck);

                //display hands
                player1.Display_player(player1.hand);
                System.Console.WriteLine("\nYou have {0} points", player1.sum);
                dealer.Display_dealer(dealer.hand);

                //start game
                System.Console.WriteLine("type hit or stay");
                string play = Console.ReadLine();
                player1.game(play, deck, dealer);

                //play again?
                System.Console.WriteLine("Play again? (y/n)");
                string playAgain = Console.ReadLine();
                if(playAgain == "y"){
                    player1.game(play, deck, dealer);
                }
            }

        }
    }
}
