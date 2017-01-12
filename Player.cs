using System;
using System.Collections.Generic;

namespace DeckOfCards{
    public class Player{
        public string name{get; set;}
        public List<Card> hand = new List<Card>();

        public int sum = 0;

        public Player(string n){
            name = n;
        }
        public Card Draw(Deck deck){
            Card drawn = deck.deal();
            hand.Add(drawn);
            checkForAce(drawn);
            sum += drawn.points;
            return drawn;
        }

        public bool Discard(Card card){
            return hand.Remove(card); //look at how .Remove() works and how it returns true/false
        }

        public Card Discard(int CardIdx){
            if(hand[CardIdx] != null){
                Card toReturn = hand[CardIdx];
                hand.RemoveAt(CardIdx);
                return toReturn; 
            }
            return null;
        }
        public void Display_player(List<Card> hand){
            System.Console.WriteLine("This is your hand:");
                for(int i = 0; i <hand.Count; i++){
                    System.Console.WriteLine("\t" + hand[i] + " ");
                
                }
        }
        public void Display_dealer(List<Card> hand, int idx){
            System.Console.WriteLine("This is my hand:");
                for(int i = idx; i <hand.Count; i++){
                    System.Console.WriteLine("\t" + hand[i] + " ");
                }
        }

        private void checkForAce(Card card){
            if(card.val == "A")
            { 
                if(sum<=10){
                    card.points = 11;
                }
                else{
                   card.points = 1; 
                }
            }           
        }

        public void playAgain(Deck deck, Player dealer){
            System.Console.WriteLine("Play again? (y/n)");
                string playagain = Console.ReadLine();
                if(playagain == "y"){
                    deck.reset();
                    deck.shuffle();
                    sum = 0;
                    dealer.sum = 0;
                    dealer.hand.Clear();
                    hand.Clear();

                    Draw(deck); 
                    Draw(deck);
                    dealer.Draw(deck);
                    dealer.Draw(deck);

                    Display_player(hand);
                    System.Console.WriteLine("\nYou have {0} points", sum);
                    dealer.Display_dealer(dealer.hand, 1);

                    //start game
                    if(sum == 21){
                        System.Console.WriteLine("Blackjack! You win!");
                        playAgain(deck, dealer);
                    }
                    else{
                        System.Console.WriteLine("type hit or stay");
                        string play = Console.ReadLine();
                        game(play, deck, dealer);
                    }
                }  
                else{
                    System.Console.WriteLine("Bye,See you again!");
                }
        }

        public void game(string play, Deck deck, Player dealer){
            if(sum == 21){
                System.Console.WriteLine("Blackjack! You win!");
                playAgain(deck, dealer);
            }
            else{
                while(play == "hit"){
                     Draw(deck);
                     Display_player(hand);
                     System.Console.WriteLine("You have {0} points", sum);
                     
                     if(sum >= 21){
                         break;
                     }
                     System.Console.WriteLine("type hit or stay");
                     play = Console.ReadLine();
                }

                if(play =="stay"){
                    while(dealer.sum < 17){
                        System.Console.WriteLine("\nDealer has {0} points", dealer.sum);
                        System.Console.WriteLine("Dealer draws a card");
                        dealer.Draw(deck);
                        dealer.Display_dealer(dealer.hand, 0);

                    }
                    if(dealer.sum < 22){
                        if(dealer.sum < sum){
                            System.Console.WriteLine("\nDealer has {0} points", dealer.sum);
                            System.Console.WriteLine("You win!");
                        }
                        else{
                            System.Console.WriteLine("\nDealer has {0} points", dealer.sum);
                            System.Console.WriteLine("You lose :(");
                        }
                    }
                    if(dealer.sum >= 22){
                        System.Console.WriteLine("Dealer busts, you win!");
                    }
                }

                if(sum == 21){
                        System.Console.WriteLine("BlackJack!");
                    }
                if(sum > 21){
                    System.Console.WriteLine("Better luck next time.");
                }

                playAgain(deck, dealer);
              
        }
    }
}
}