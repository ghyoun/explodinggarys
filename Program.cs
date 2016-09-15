using System;

namespace ConsoleApplication
{
   public class Program
   {
       public static void Main(string[] args)
       {
           Console.WriteLine("Welcome to Exploding Peanuts!")
           Console.WriteLine("Hello, Please Select The Number Of Players (2-5).")
           int result;
           int explodingKittens;
           int numDifffuses;
           string playerName;
        
           if(int.TryParse(Console.ReadLine(), out result))

               if (result == 2){
                   explodingKittens = 1
                   numDifffuses = result
               }
               if (result == 3){
                   explodingKittens = 2
                   numDiffuses = result
               }
               if (result == 4){
                   explodingKittens = 3
                   numDifffuses = result
               }
               if (results == 5){
                   explodingKittens = 4
                   numDifffuses = result
               } else{
                   Console.WriteLine("Please enter the acceptable amount of players!")
               }
            
                Deck remainingDeck = new Deck(numberofPlayers);
                deal();
                
                for (int i = 0; i < result; i++) 
                    {
                        Player newChallenger = new Players(playerName); 
                        Console.WriteLine("Please Insert Player Name".)
                        string playerName = Console.ReadLine():
                        playerName[i]  = new Player(playerName);    
                    }
        }
    }
}
