using System;

namespace ConsoleApplication
{
    public class Deck
    {
        public Card[] cards;

        public Deck(int numberofPlayers)
        {
            cards = new Card[46 + numberofPlayers - 1];
        }


        //Shuffles the deck
        public void shuffle()
        {
            int length = cards.Length;
            Card t;
            int index = 0;
            Random rnd = new Random();
            while (length > 0) {
                index = rnd.Next(0, length-1);

                t = cards[length-1];
                cards[length-1] = cards[index];
                cards[index] = t;
                length--;
            }
        }

        //checks the number of cards in the deck
        //returns the number of cards left
        public int cardsInDeck()
        {
            return cards.Length;
        }

        //Deals the top card from the deck
        //Returns the top card object
        public Card deal()
        {
            Card holder = cards[cards.Length-1];
            Array.Resize(ref cards, cards.Length-1);
            return holder;
        }


        //Returns a string with the top three cards in the deck
        public string peek()
        {
            if (cardsInDeck() > 2) {
                return "Top Card: " + cards[cards.Length-1].name + ", Next Card: " + cards[cards.Length-2].name + ", Next Card: " + cards[cards.Length-3].name;
            } else if (cardsInDeck() > 1) {
                return "Top Card: " + cards[cards.Length-1].name + ", Next Card: " + cards[cards.Length-2].name;
            } else {
                return "Top Card: " + cards[cards.Length-1].name;
            }
        }
    }

    
}