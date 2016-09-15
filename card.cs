using System;
using System.Collections.Generic;

namespace ConsoleApplication
{

    public class Card
    {
        public string name; 
        public Dictionary<string,int> all_cards = new Dictionary<string,int>()
        {
            { "Beard_cat", 4 },
            { "Cattermelon", 4 },
            { "Hairy_potato_cat", 4 },
            { "Rainbow_cat", 4 },
            { "Taco_cat", 4 },
            { "Attack", 4 },
            { "Favor", 4 },
            { "Nope", 5 },
            { "See_future", 5 },
            { "Shuffle", 4 },
            { "Skip", 4 },

        };
           
        // "Attack","Defuse","Exploding_Kitten","Favor","Nope","See_the_Future","Shuffle","Skip"};
        public Card(string cardName)
        {
            name = cardName;
        }

     
        public object[] Attack()
        {
            // return false to required deal action and pass on 2 deals actoin to the next player               
            object[] attack = new object[] {false,"deal_method_here","deal_method_here"};
            return attack;
        }

        public bool Exploding_Kitten()
        {
            // return false to player.alive
            return false;
        }




    }
}
