using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
   public class Program
   {
       public static void Main(string[] args)
       {
           Console.WriteLine("Welcome to Exploding Peanuts!");
           Console.WriteLine("Hello, Please Select The Number Of Players (2-5).");
           int result;
           int explodingKittens = 0;
           int numDiffuses = 0;
           LinkedList<Player> allPlayers = new LinkedList<Player>();

           
           while (explodingKittens == 0)
           {
               if(int.TryParse(Console.ReadLine(), out result))
               {
                    explodingKittens = result-1;
                    numDiffuses = result;
                } else {
                        Console.WriteLine("Please enter the acceptable amount of players!");
                }
           }
           
            
            Deck remainingDeck = new Deck(numDiffuses);
            Discard discardPile = new Discard();
            remainingDeck.shuffle();
            
            for (int i = 0; i < numDiffuses; i++) 
            {
                Console.WriteLine("Please Insert Player Name");
                string playerName = Console.ReadLine();
                Player temp = new Player(playerName);  
                temp.getCard(new Card("Defuse"));
                for (int j = 0; j < 4; j++) 
                {
                    temp.drawCard(remainingDeck);
                }
                allPlayers.AddLast(temp); 
            }
            for (int i = 0; i < explodingKittens; i++)
            {
                remainingDeck.addSpecificCard(new Card("Exploding_Kittens"));
            }
            for (int i = 0; i < 6-numDiffuses; i++)
            {
                remainingDeck.addSpecificCard(new Card("Defuse"));
            }
            remainingDeck.shuffle();

            //Starting the turns
            LinkedListNode<Player> current = allPlayers.First;
            while(allPlayers.Count > 1)
            {
                Console.WriteLine("*************" + current.Value.name + "'s Turn*************");
                bool stillTurn = true;
                bool skippedTurn = false;
                while (stillTurn)
                {
                    Console.WriteLine("*************" + current.Value.name + "'s Hand*************");
                    current.Value.displayCards();
                    Console.WriteLine("*************POSSIBLE PLAYS*************");
                    current.Value.displayPossiblePlays();
                    bool notValid = true;
                    while (notValid)
                    {
                        Console.WriteLine("*************" + current.Value.name + "'s Play*************");
                        Console.WriteLine("*************(Select Your Next Play)*************");
                        var userInput = Console.ReadLine();
                        int temp;
                        if(int.TryParse(userInput, out temp))
                        {
                            int intInput = int.Parse(userInput);
                            if (intInput >= 1 && intInput <= current.Value.singles.Length)
                            {
                                if (current.Value.singles[intInput-1] == "See_future")
                                {
                                    Console.WriteLine("Seeing the Future ---->");
                                    Console.WriteLine(remainingDeck.peek());
                                    discardPile.addToDiscard(current.Value.removeCard("See_future"));
                                } else if (current.Value.singles[intInput-1] == "Shuffle") {
                                    Console.WriteLine("Shuffling Deck...");
                                    discardPile.addToDiscard(current.Value.removeCard("Shuffle"));
                                } else if (current.Value.singles[intInput-1] == "Favor") {
                                    Console.WriteLine("Asking for a Favor...");
                                    LinkedListNode<Player> pointer = allPlayers.First;
                                    int pointerIndex = 0;
                                    while(pointer != null)
                                    {
                                        Console.WriteLine("[" + (pointerIndex + 1) + "]. " + pointer.Value.name);
                                    }
                                    bool validUser = false;
                                    while (!validUser)
                                    {
                                        Console.WriteLine("(Enter a valid index)");
                                        string playerIndex = Console.ReadLine();
                                        if (int.TryParse(playerIndex, out temp))
                                        {
                                            if (temp > 0 && temp <= allPlayers.Count)
                                            {
                                                pointer = allPlayers.First;
                                                while(temp > 1)
                                                {
                                                    pointer = pointer.Next;
                                                    temp--;
                                                }
                                                validUser = !validUser;
                                                Console.WriteLine("*************" + pointer.Value.name + "'s Hand*************");
                                                Console.WriteLine("(Pick a card to give to " + current.Value.name +")");
                                                pointer.Value.displayCards();
                                                int favorIndex = int.Parse(Console.ReadLine());
                                                pointer.Value.giveFavor(current.Value, favorIndex-1);
                                            } else {
                                                Console.WriteLine("Non Existed Player");
                                            }
                                        } else {
                                            Console.WriteLine("Non Existed Player");
                                        }
                                    }
                                    Console.WriteLine("Favor Given");
                                    discardPile.addToDiscard(current.Value.removeCard("Favor"));
                                } else if (current.Value.singles[intInput-1] == "Skip") {
                                    skippedTurn = true;
                                    discardPile.addToDiscard(current.Value.removeCard("Skip"));
                                } else if (current.Value.singles[intInput-1] == "End") {
                                    Console.WriteLine("Player Has Ended Turn...Commencing Draw");
                                    notValid = false;
                                }
                                notValid = false;
                            } else if (intInput <= -1 && intInput >= (current.Value.doublePlays.Length * -1)) {
                                Console.WriteLine("There");
                                notValid = false;
                            } else {
                                Console.WriteLine("Option doesn't exist");
                            }
                        } else {
                            int charInput = (userInput).ToString().ToUpper().ToCharArray()[0] - 64;
                            if (charInput >= 1 && charInput <= current.Value.triplePlays.Length)
                            {
                                Console.WriteLine("I guess");
                                notValid = false;
                            } else {
                                Console.WriteLine("Option doesn't exist");
                            }
                        }
                    }
                    if (!skippedTurn) 
                    {
                        Card newlyDrawn = current.Value.drawCard(remainingDeck);
                        if (newlyDrawn.name == "Exploding_Kittens")
                        {
                            Console.WriteLine("YOU DREW AN EXPLODING KITTEN!!");
                            if (!current.Value.contains("Defuse"))
                            {
                                current.Value.alive = false;
                                if (current.Previous == null)
                                {
                                    allPlayers.RemoveFirst();
                                } else if (current.Next == null)
                                {
                                    allPlayers.RemoveLast();
                                }else {
                                    allPlayers.Remove(current.Value);
                                }
                                Console.WriteLine(current.Value.name + " DIES!");
                            } else {
                                current.Value.removeCard("Defuse");
                                current.Value.removeCard("Exploding_Kittens");
                                if (remainingDeck.cardsInDeck() == 0)
                                {
                                    Console.WriteLine("You Put it On the Top of the Deck");
                                    remainingDeck.addSpecificCard(new Card("Exploding_Kittens"));
                                } else {
                                    Console.WriteLine("There are " + remainingDeck.cardsInDeck() + "cards in the deck (Pick between 0[bottom] and the # of cards[top]");
                                    int explodingIndex = int.Parse(Console.ReadLine());
                                    remainingDeck.addSpecificCardSpecificIndex(new Card("Exploding_Kittens"), explodingIndex);
                                }
                            }
                        }
                        stillTurn = false;
                    } else {
                        skippedTurn = false;
                        stillTurn = false;
                    }
                }

                
            }
        }
    }
}
