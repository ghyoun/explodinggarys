using System;

namespace ConsoleApplication
{
    public class Player
    {
        public string name;
        public Card[] hand;
        public bool alive;

        public Player(string givenName)
        {
            name = givenName;
            hand = new Card[0];
            alive = true;
        }

        public void shuffleHand()
        {
            
            int length = hand.Length;
            Card t;
            int index = 0;
            Random rnd = new Random();
            while (length > 0) {
                index = rnd.Next(0, length-1);

                t = hand[length-1];
                hand[length-1] = hand[index];
                hand[index] = t;
                length--;
            }
        }

        public Card drawCard(Deck ourDeck)
        {
            Card drawnCard = ourDeck.deal();
            Array.Resize(ref hand, hand.Length+1);
            hand[hand.Length-1] = drawnCard;
            return drawnCard;
        }

        public void getCard(Card newCard)
        {
            Array.Resize(ref hand, hand.Length+1);
            hand[hand.Length-1] = newCard;
        }

        public void twoOfAKind(Player opponent, int handIndex)
        {
            getCard(takeCard(opponent, handIndex));
        }

        private Card takeCard(Player opponent, int handIndex)
        {
            Card holder = opponent.hand[handIndex];
            if (handIndex != opponent.hand.Length-1)
            {
                for (int i = handIndex; i < opponent.hand.Length; i++)
                {
                    opponent.hand[i] = opponent.hand[i+1];
                }
            }
            Array.Resize(ref opponent.hand, hand.Length-1);
            return holder;
        }

        public bool contains(Card checkCard)
        {
            foreach(Card card in hand)
            {
                if (card.name == checkCard.name)
                {
                    return true;
                }
            }
            return false;
        }
    }

    
}