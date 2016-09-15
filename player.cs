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

        //Shuffles this player's hand
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

        //Draws the top card from the Deck
        //Takes in a Deck object
        //Returns the drawn Card
        public Card drawCard(Deck ourDeck)
        {
            Card drawnCard = ourDeck.deal();
            Array.Resize(ref hand, hand.Length+1);
            hand[hand.Length-1] = drawnCard;
            return drawnCard;
        }

        //A method to get a specific type of card
        //Takes in a Card Object
        public void getCard(Card newCard)
        {
            Array.Resize(ref hand, hand.Length+1);
            hand[hand.Length-1] = newCard;
        }


        //A method for two of a kind
        //Takes in the opponent who the player wants to steal a card from and the index of the hand Array
        public void twoOfAKind(Player opponent, int handIndex)
        {
            getCard(takeCard(opponent, handIndex));
        }

        //A method when a player has favor used on him/her
        //Takes in the opponent who activated the card on him/her and the index of the card the victim wants to giveFavor
        public void giveFavor(Player opponent, int handIndex)
        {
            opponent.getCard(pickCard(handIndex));
        }

        private Card pickCard(int handIndex)
        {
            Card holder = hand[handIndex];
            if (handIndex != hand.Length-1)
            {
                for (int i = handIndex; i < hand.Length; i++)
                {
                    hand[i] = hand[i+1];
                }
            }
            Array.Resize(ref hand, hand.Length-1);
            return holder;
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
            Array.Resize(ref opponent.hand, opponent.hand.Length-1);
            return holder;
        }

        //checks if the name of the card is in the player's hand
        //takes in the name of the card to checkCard
        //returns a bool values true if the card is in the hand
        public bool contains(string checkCard)
        {
            foreach(Card card in hand)
            {
                if (card.name == checkCard)
                {
                    return true;
                }
            }
            return false;
        }
    }

    
}