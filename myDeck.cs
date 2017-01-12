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
            string[] suitSymbols = new string[4] {"♠", "♦", "♥", "♣"};
            string[] values =  new string[14]{"0","A","2","3","4","5","6","7","8","9","10","J","Q","K"};
            
            string img;
            for(int i = 0; i < suits.Length; i++){    
                for(int n = 1; n < 14; n++){
                    string space = " ";
                    if(n == 1){
                        points = 11;
                    }
                    else if (n>10){
                        points = 10;
                    }else{
                        points = n;
                    }

                    if(n == 11){
                        space = "";
                        }
                    img = "\n___________\n|"+ space + values[n]+"       |\n|         |\n|         |\n|    " + suitSymbols[i] +"    |\n|         |\n|         |\n|       "+ values[n] + space + "|\n|_________|\n";
                    cards.Add(new Card(suits[i], n, points, img));
                }
            }
        }

        public Card deal(){
            if(cards.Count%2 == 0){
                for(int i = 0; i<cards.Count;i++){
                    if(cards[i].val == "A"){
                        Card temp = cards[i];    // to generate Ace for testing
                        cards[i]= cards[0];
                        cards[0]= temp;
                        break;
                    }
                }
            }
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