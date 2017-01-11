using System; //get us access to whatever system we are on, need it for console logging
using System.Collections.Generic;

namespace DeckOfCards{
    public class Deck{
        public List<Card> cards; //can initialize list here but...
        public Deck(){
           reset();
        }

        public void reset(){
            cards = new List<Card>(); // by initalizing the cards here you can re-initalize and not add cards to the end of the list and have lots of extra cards vs initializing above and having to clear the list
            string[] suits = new string[4] {"Hearts","Clubs","Spades","Diamonds"};
            int points;
            for(int i = 0; i < suits.Length; i++){
                for(int n = 1; n < 14; n++){
                    if (n>10){
                        points = 10;
                    }else{
                        points = n;
                    }

                    cards.Add(new Card(suits[i], n, points));
                }
            }
        }

        public Card deal(){
            Card toReturn = cards[0];
            cards.RemoveAt(0);
            return toReturn;
        }

        public void shuffle(){
            Random rand =  new Random(); //make the instance outside of the for loop :)
            for(int i = cards.Count - 1; i > 0; i--){ //Fisher-Yates everything will be in a different spot
                int randIdx = rand.Next(cards.Count - i);
                Card swap = cards[i];
                cards[i] = cards[randIdx];
                cards[randIdx] = swap;
            }
        }

        public override string ToString(){
            string str = "";
            foreach(Card card in cards){
                str += card + "\n";
            }
            return str;
        }
    }
}