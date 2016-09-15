using System;

namespace ConsoleApplication
{

    public class Card
    {
        public string name; 
        // {"Beard_Cat","CatterMelon","Hairy_Potato_Cat","Rainbow_Cat","Taco_Cat",
        //"Attack","Defuse","Exploding_Kitten","Favor","Nope","See_the_Future","Shuffle","Skip"}
    

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

        public bool Skip()
        {
            // retur false to required deal action
            return false;
        }

        public void Shuffle_card()
        {
            // call shuffle function
            
        }

        public string[] See_Future()
        {
            // pick first top 3 cards on the top of the deck and return them back in order
            string[] future = new string[3];
            return future;
        }

        public void Nope()
        {
            // stop any action execpt an exploidng kitten or defuse card 
            
        }



    }

      

}
