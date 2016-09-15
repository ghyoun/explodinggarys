using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    public class Deck
    {
        public Card[] cards;
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
        public Deck(int numberofPlayers)
        {
            cards = new Card[46];
            int index = 0;
            foreach(KeyValuePair<string, int> entry in all_cards)
            {
                // do something with entry.Value or entry.Key
                for (int i = 0; i < entry.Value; i++)
                {
                    cards[index] = new Card(entry.Key);
                    index++;
                }
            }
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