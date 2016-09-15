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
            hand = new Card[];
            alive = true;
        }
    }

    
}