using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Player
    {
        public string name;
        public Card[] hand;
        public bool alive;

        public string[] singles;

        public string[] doublePlays;

        public string[] triplePlays;


        public Player(string givenName)
        {
            name = givenName;
            hand = new Card[0];
            alive = true;
            singles = new string[0];
            doublePlays = new string[0];
            triplePlays = new string[0];
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

        public void displayCards()
        {
            for(int i = 0; i < hand.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + hand[i].name);
            }
        }

        public Card removeCard(string cardName)
        {
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i].name == cardName)
                {
                    Card holder = hand[i];
                    while (i < hand.Length-1)
                    {
                        hand[i] = hand[i + 1];
                        i++;
                    }
                    Array.Resize(ref hand, hand.Length-1);
                    return holder;
                }
            }
            return null;
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

        public void displayPossiblePlays()
        {
            int i = 1;
            int j = -1;
            char k = 'A';
            HashSet<String> unique = uniqueCards();
            singles = new string[0];
            doublePlays = new string[0];
            triplePlays = new string[0];
            foreach(String card in unique)
            {
                if (card != "Nope" && card != "Defuse" && card != "Taco_cat" && card != "Cattermelon" && card != "Beard_cat" && card != "Hairy_potato_cat" && card != "Rainbow_cat")
                {
                    Console.WriteLine("[" + i + "]. " + card);
                    Array.Resize(ref singles, singles.Length+1);
                    singles[singles.Length-1] = card;
                    i++;
                }
            }
            Console.WriteLine("[" + i + "]. End");
            Array.Resize(ref singles, singles.Length+1);
            singles[singles.Length-1] = "End";
            i++;
            HashSet<String> doubles = giveDoubles();
            foreach(String eachDouble in doubles)
            {
                Console.WriteLine("[" + j + "]. " + eachDouble + " : Pair");
                Array.Resize(ref doublePlays, doublePlays.Length+1);
                doublePlays[doublePlays.Length-1] = eachDouble;
                j--;
            }
            HashSet<String> triples = giveTriples();
            foreach(String eachTriple in triples)
            {
                Console.WriteLine("[" + k + "]. " + eachTriple + " : Triplet");
                Array.Resize(ref triplePlays, triplePlays.Length+1);
                triplePlays[triplePlays.Length-1] = eachTriple;
                k++;
            }
        }

        public int numberOfUnique()
        {
            return uniqueCards().Count;
        }

        public HashSet<String> giveDoubles()
        {
            Player temp = new Player("Temp");
            HashSet<String> doubles = new HashSet<String>();
            foreach(Card card in hand)
            {
                if(temp.contains(card.name))
                {
                    doubles.Add(card.name);
                } else {
                    temp.getCard(card);
                }   
            }
            return doubles;
        }
        public bool hasDoubles()
        {
            if (giveDoubles().Count > 0)
            {
                return true;
            } 
            return false;
        }

        public bool hasTriples()
        {
            if (giveTriples().Count > 0)
            {
                return true;
            } 
            return false;
        }

        public HashSet<String> giveTriples()
        {
            HashSet<String> triples = new HashSet<String>();
            int[] counts = new int[12];
            foreach(Card card in hand)
            {
                if (card.name == "Defuse")
                {
                    counts[0]++;
                } else if (card.name == "Beard_cat") {
                    counts[1]++;
                } else if (card.name == "Cattermelon") {
                    counts[2]++;
                } else if (card.name == "Hairy_potato_cat") {
                    counts[3]++;
                } else if (card.name == "Rainbow_cat") {
                    counts[4]++;
                } else if (card.name == "Taco_cat") {
                    counts[5]++;
                } else if (card.name == "Attack") {
                    counts[6]++;
                } else if (card.name == "Favor") {
                    counts[7]++;
                } else if (card.name == "Nope") {
                    counts[8]++;
                } else if (card.name == "See_future") {
                    counts[9]++;
                } else if (card.name == "Shuffle") {
                    counts[10]++;
                } else if (card.name == "Skip") {
                    counts[11]++;
                }
            }
            for(int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 2)
                {
                    if (i == 0) {
                        triples.Add("Defuse");
                    } else if (i == 1) {
                        triples.Add("Beard_cat");
                    } else if (i == 2) {
                        triples.Add("Cattermelon");
                    } else if (i == 3) {
                        triples.Add("Hairy_potato_cat");
                    } else if (i == 4) {
                        triples.Add("Rainbow_cat");
                    } else if (i == 5) {
                        triples.Add("Taco_cat");
                    } else if (i == 6) {
                        triples.Add("Attack");
                    } else if (i == 7) {
                        triples.Add("Favor");
                    } else if (i == 8) {
                        triples.Add("Nope");
                    } else if (i == 9) {
                        triples.Add("See_future");
                    } else if (i == 10) {
                        triples.Add("Shuffle");
                    } else if (i == 11) {
                        triples.Add("Skip");
                    }
                }
            }
            return triples;
        }
        private HashSet<String> uniqueCards()
        {
            HashSet<String> uniques = new HashSet<String>();
            foreach(Card card in hand)
            {
                uniques.Add(card.name);
            }
            return uniques;
        }
    }

    
}