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
    }
}