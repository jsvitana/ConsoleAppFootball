using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFootball
{
    class Teams
    {
        public string name;
        public int overallRate;            //Average rate of whole team
        public int score;                  //score is kept here, team with highest score in end wins
        public int passingRate;
        public int catchingRate;
        public int runningRate;            //adds up all the stats of current postion players and gives them an average rate
        public int runDefRate;
        public int passDefRate;
        public int blockingRate;
        public bool isOff;                 //Determines whether this team is on Offence or Defence 
        public static bool[] cityFlags = new bool[10];
        public static bool[] adjectiveFlags = new bool[10];
        public static bool[] mascotFlags = new bool[10];


        public Teams()  //Default constructor
        {
            this.name = "";
            this.overallRate = 0;
            this.score = 0;
            this.passingRate = 0;
            this.catchingRate = 0;
            this.runningRate = 0;
            this.runDefRate = 0;
            this.passDefRate = 0;
            this.blockingRate = 0;           //unused stat as of now, will later be used for how well O line does in protecting QB, RB, ETC
            this.isOff = false;
        }

        public override string ToString()
        {
            return this.name +
                "\nOverall Team Average: " + this.overallRate +
                "\nPassing Rate: " + this.passingRate +
                "\nCatching Rate: " + this.catchingRate +
                "\nRunning Rate: " + this.runningRate +
                "\nRun Defence Rate: " + this.runDefRate +
                "\nPassing Defence Rate: " + this.passDefRate +
                "\nBlocking Rate: " + this.blockingRate;
        }

        public void nameTeam(bool human)                                     //Lets user choose name and gives the computer a random name
        {
            if (human)
            {
                Console.WriteLine("What would you like your team name to be?");
                Console.WriteLine("Or type ? to get a random name");
                this.name = Program.getString();
                Console.Clear();
            }

            if(this.name == "?")
            {
                human = false;
            }

            if(!human)
            {
                int pick = 0;
                string city = "";                                      
                string adjective = "";
                string mascot = "";
                string[] cities = { "Hopewell", "Toledo", "Durham", "San Antonio", "Milwaukee", "Baton Rouge", "Arlington", "Greensboro", "Wichita", "Albuquerque" };
                string[] mascots = { " Puppys", " Armadillos", " Roosters", " Cows", " Impalas", " Starfish", " Dung Beetles", " Walruses", " Camels", " Kangaroos" };
                string[] adjectives = { " Cowerdly", " Cocky", " Fluffy", " Painfully Honest", " Drunken", " Godawful", " Alcoholic", " Misunderstood", " Twisted", " Fighting" };

                pick = Program.rng.Next(0, 10);
                while(cityFlags[pick] == true)
                {
                    pick = Program.rng.Next(0, 10);
                }
                city = cities[pick];
                cityFlags[pick] = true;

                pick = Program.rng.Next(0, 10);
                while (adjectiveFlags[pick] == true)
                {
                    pick = Program.rng.Next(0, 10);
                }
                adjective = adjectives[pick];
                adjectiveFlags[pick] = true;

                pick = Program.rng.Next(0, 10);
                while (mascotFlags[pick] == true)
                {
                    pick = Program.rng.Next(0, 10);
                }
                mascot = mascots[pick];
                mascotFlags[pick] = true;
                this.name = city + adjective + mascot;
            }
        }

        public void averageTeams(Players[] players)
        {
            int totalAverage = 0;
            int sumOfPassing = 0;
            int sumOfCatching = 0;
            int sumOfRunning = 0;
            int sumOfRunDef = 0;
            int sumOfPassDef = 0;
            int sumOfBlocking = 0;

            for(int i = 0;i<22;i++)                                        //uses only the average of the position to rank teams 
            {
                if (players[i].position == "Quarterback")
                {
                    sumOfPassing += players[i].passing;
                }
                else if (players[i].position == "Running Back")
                {
                    sumOfRunning += players[i].running;
                }
                else if (players[i].position == "Wide Receiver")
                {
                    sumOfCatching += players[i].catching;
                }
                else if (players[i].position == "Linebacker")
                {
                    sumOfRunDef += players[i].runDef;
                }
                else if (players[i].position == "Defensive Back")
                {
                    sumOfPassDef += players[i].passDef;
                }
                else if (players[i].position == "Offensive Lineman")
                {
                    sumOfBlocking += players[i].blocking;
                }
            }
            this.passingRate = sumOfPassing / 1;
            this.runningRate = sumOfRunning / 1;
            this.catchingRate = sumOfCatching / 4;
            this.runDefRate = sumOfRunDef / 7;
            this.passDefRate = sumOfPassDef / 4;
            this.blockingRate = sumOfBlocking / 5;
            totalAverage = this.passingRate + this.catchingRate + this.runningRate + this.runDefRate + this.passDefRate + this.blockingRate;
            this.overallRate = totalAverage / 6;

        }
    }
}
