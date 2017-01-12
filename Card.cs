using System;


namespace DeckOfCards{
    public class Card{

        public string val {get{ //cannot use the variable name 'val' in get or set or you will end up in an infinite loop ///{get; set} will make it behave as noraml
             if(num_val > 1 && num_val < 11){
                return num_val.ToString();
            } 
            else if(num_val == 11){ //cannot use val. it will call val get function and get stuck in infinite looop. Instead use "return"
                return "J";
            }
            else if(num_val == 12){
                return "Q";
            }
            else if(num_val == 13){
                return "K";
            }
             else if(num_val == 1){
                return "A";
            }
            else{
                return "Joker";
            }
        }
        }

        //HOW TO MAKE THE ACE CHANGE VALUE?
        public int points;
        // {get{
        //     if(num_val == 1 && sum < 10){
        //         return 11;
        //     }
        // } set{}}





        public int num_val;
        public string suit;
        public Card(string s, int num, int pt){
            suit = s;
            num_val = num;  
            points = pt;
        }

        public override string ToString(){
            return val + " of " + suit;
        }
    }
}