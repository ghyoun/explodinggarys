using System;

namespace ConsoleApplication
{

    // -------------- General Card Class -----------------
    public class Card
    {
        public string name; 
        // {"Beard_Cat","CatterMelon","Hairy_Potato_Cat","Rainbow_Cat","Taco_Cat",
        //"Attack","Defuse","Exploding_Kitten","Favor","Nope","See_the_Future","Shuffle","Skip"}
    

        public void Card(string cardName)
        {
            name = cardName
        }

        // +++++++++++++ ACTION CARD METHOD ++++++++++++++++
        public void Attack()
        {
                
        }

        public void Exploding_Kitten()
        {
            Player.alive = false;
        }

        // +++++++++++++ END +++++++++++++++++++++++++++++++

    }

        // -------------- END --------------------------------

}
