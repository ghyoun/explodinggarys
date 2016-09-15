using System;

namespace ConsoleApplication
{

    public class Discard
    {
        public Card[] pile; 
    

        public Discard()
        {
            pile = new Card[0];
        }

        public int cardsInDiscard()
        {
            return pile.Length;
        }
    }

        // -------------- END --------------------------------

}