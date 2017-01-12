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
                    System.Console.Write(hand[i] + " ");
                
                }
        }
        public void Display_dealer(List<Card> hand){
            System.Console.WriteLine("This is my hand:");
                for(int i = 1; i <hand.Count; i++){
                    System.Console.Write(hand[i] + " ");
                }
        }

        public void checkForAce(List<Card> hand){
            if (sum > 21){
                for( int i = 0; i < hand.Count; i++){
                    if(hand[i].val == "Ace"){
                        hand[i].points = 1;
                        sum -= 10;
                        break; //CONSIDER TWO ACES
                    }
                }
            }
        }

        public void game(string play, Deck deck, Player dealer){
            if(sum == 21){
                System.Console.WriteLine("Blackjack! You win!");
            }
            checkForAce(hand);//in case you get two aces

            while(play == "hit"){
                     Draw(deck);
                     Display_player(hand);
                     System.Console.WriteLine("You have {0} points", sum);
                     checkForAce(hand);
                     if(sum >= 21){
                         break;
                     }
                     System.Console.WriteLine("type hit or stay");
                     play = Console.ReadLine();
                }

                if(play =="stay"){
                    checkForAce(dealer.hand);
                    while(dealer.sum < 17){
                        System.Console.WriteLine("\nDealer has {0} points", dealer.sum);
                        System.Console.WriteLine("Dealer draws a card");
                        dealer.Draw(deck);
                        dealer.Display_player(dealer.hand);
                        checkForAce(dealer.hand);
                    }
                    if(dealer.sum < 22){
                        if(dealer.sum < sum){
                             checkForAce(dealer.hand);
                            System.Console.WriteLine("\nDealer has {0} points", dealer.sum);
                            System.Console.WriteLine("You win!");
                        }
                        else{
                             checkForAce(dealer.hand);
                            System.Console.WriteLine("\nDealer has {0} points", dealer.sum);
                            System.Console.WriteLine("You lose :(");
                        }
                    }
                    if(dealer.sum >= 22){
                         checkForAce(dealer.hand);
                        System.Console.WriteLine("Dealer busts, you win!");
                    }
                }

                if(sum == 21){
                        System.Console.WriteLine("BlackJack!");
                    }
                if(sum > 21){
                    System.Console.WriteLine("Better luck next time.");
                }
        }
    }
}