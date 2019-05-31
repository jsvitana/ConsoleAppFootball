using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFootball
{
    class Players
    {
        public static Random rng = new Random();
        ////////stats/////////////
        public int playerNumber;
        public int passing;
        public int catching;
        public int running;
        public int runDef;
        public int passDef;
        public int blocking;
        public string position;
        
        public Players()        //default contructor
        {
            this.playerNumber = rng.Next(1, 100);
            this.passing = rng.Next(75, 101);
            this.catching = rng.Next(75, 101);
            this.running = rng.Next(75, 101);
            this.runDef = rng.Next(75, 101);
            this.passDef = rng.Next(75, 101);
            this.blocking = rng.Next(75, 101);
        }

        public Players(int playerNumber,int passing,int catching,int running,int runDef,int passDef,int blocking)    //set this up in initPlayers
        {
            this.playerNumber = playerNumber;
            this.passing = passing;
            this.catching = catching;
            this.running = running;
            this.runDef = runDef;
            this.passDef = passDef;
            this.blocking = blocking;
        }

        public void showStats()
        {
            Console.WriteLine("Jersey Number: " + this.playerNumber);
            Console.WriteLine("Position: " + this.position);
            Console.WriteLine("Passing: " + this.passing);
            Console.WriteLine("Catching: " + this.catching);
            Console.WriteLine("Running: " + this.running);
            Console.WriteLine("Run Defence: " + this.runDef);
            Console.WriteLine("Pass Defence: " + this.passDef);
            Console.WriteLine("Blocking: " + this.blocking);
        }
    }
}
