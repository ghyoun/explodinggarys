using System;
using System.Collections.Generic;

namespace ConsoleApplication
{

    public class Card
    {
        public string name; 
        
           
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
