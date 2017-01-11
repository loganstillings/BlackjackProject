using System;
// using Cards if you wanted card to have namespace card

namespace DeckOfCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Card myCard = new Card("Clubs", 6);
            // Card myCard2 = new Card("Hearts", 1);
            // Console.WriteLine(myCard.val); //when you run it goes to Card string val get function and 'gets' the return value from the get function we wrote!
            // Console.WriteLine(myCard2.val);

            // Deck myDeck = new Deck();
            // Console.WriteLine(myDeck.deal());
            // Console.WriteLine(myDeck);
            // myDeck.shuffle();
            // Console.WriteLine(myDeck);

            // Player Liz =  new Player("Liz");
            // Liz.Draw(myDeck);
            // Console.WriteLine(Liz.hand[0]);

            Console.WriteLine("Would you like to play BlackJack?(y/n) ;)");
            string answer = Console.ReadLine();
            if (answer == "n"){
                System.Console.WriteLine("K bye :(");
            }
            else {
                System.Console.WriteLine("Welcome to Casino Dojo, I'll be your host, Jack.  \nWhat is your name?");
                string name = Console.ReadLine();
                Player player1 = new Player(name);
                Player dealer = new Player("Jack");
                Deck deck = new Deck();
                deck.shuffle();
                player1.Draw(deck); 
                player1.Draw(deck);
                dealer.Draw(deck);
                dealer.Draw(deck);

                player1.Display_player(player1.hand);
                System.Console.WriteLine("\nYou have {0} points", player1.sum);
                dealer.Display_dealer(dealer.hand);
                System.Console.WriteLine("type hit or stay");
                string play = Console.ReadLine();

                while(play != "stay"){
                     player1.Draw(deck);
                     player1.Display_player(player1.hand);
                     System.Console.WriteLine("You have {0} points", player1.sum);
                     System.Console.WriteLine("type hit or stay");
                     play = Console.ReadLine();

                }

                // if (play == "hit"){
                //     player1.Draw(deck);
                //     player1.Display_player(player1.hand);
                // }
                // if (play == "stay"){
                    
                // }
            }

        }
    }
}
