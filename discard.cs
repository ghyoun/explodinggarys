using System;
using System.Collections.Generic;

namespace ConsoleApplication
{

    public class Discard
    {
        public Card[] pile; 
    

        public Discard()
        {
            pile = new Card[0];
        }

        //adds a card to discard pile
        //takes in card to be discarded
        public void addToDiscard(Card trash)
        {
            Array.Resize(ref pile, pile.Length+1);
            pile[pile.Length-1] = trash;

        }

        //returns number of cards in the discard pile
        public int cardsInDiscard()
        {
            return pile.Length;
        }

        //returns a set of unique cards in the discard pile
        public HashSet<String> uniqueCards()
        {
            HashSet<String> uniques = new HashSet<String>();
            foreach(Card card in pile)
            {
                uniques.Add(card.name);
            }
            return uniques;
        }

        //takes in a card wanted from the discard pile
        //returns the card we want
        public Card takeFromDiscard(string wantedCard)
        {
            Card holder;
            for (int i = 0; i < pile.Length; i++) {
                if (pile[i].name == wantedCard)
                {
                    holder = pile[i];
                    for (int j = i; j < pile.Length; j++)
                    {
                        pile[i] = pile[i+1];
                    }
                    Array.Resize(ref pile, pile.Length-1);
                    return holder;
                }
            }
            return null;
        }
    }

        // -------------- END --------------------------------

}