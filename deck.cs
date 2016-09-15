using System;

namespace ConsoleApplication
{
    public class Deck
    {
        public Card[] cards;

        public Deck(int numberofPlayers)
        {
            cards = new Card[52 + numberofPlayers - 1];
        }

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

        public int cardsInDeck()
        {
            return cards.Length;
        }

        public Card deal()
        {
            Card holder = cards[cards.Length-1];
            Array.Resize(ref cards, cards.Length-1);
            return holder;
        }

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