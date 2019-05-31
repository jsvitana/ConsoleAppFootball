using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFootball
{
    class Program
    {
        // Global Variables //
        public static Random rng;
        public static int down = 1;          //represents what down is up
        public static int time = 500;        //how much time is left in the game
        public static int yardsToGo = 10;    //how many yards until first down is achieved
        public static int fieldPosition = 25;  //What place on the field the ball is at

        // Methods // 

        public static string getString()
        {
            String input = "";
            input = Console.ReadLine();
            return input;
        }

        public static int getInt()
        {
            int n = 0;
            String input = "";
            while (true)
            {
                input = Console.ReadLine();
                try
                {                   
                    n = Convert.ToInt32(input);
                    return n;
                }
                catch
                {
                    Console.WriteLine("That is not a valid input, please try again");
                }
            }
        }

        public static void printDirections()
        {
            Console.WriteLine("Welcome to Console App Football!");
            Console.WriteLine("Probably the most simple football game you'll ever play!");
            Console.WriteLine("Very simple, not completely balanced yet in terms of offense....");
            Console.WriteLine();
        }

        public static void showStats(Players[] players, Teams team)
        {
            int positionView = 0;       //Used in switchboard to view selected position

            Console.WriteLine("What position would you like to see? \n[1] Quarterback \n[2] Running back \n[3] Wide Recievers" +
                              "\n[4] Linebackers \n[5] Defensive Backs \n[6] Offensive Lineman \n[7] All players \n[8] View team Overalls");
            positionView = getInt();
            Console.Clear();

            switch (positionView)
            {
                case 1:
                    for (int i = 0; i < players.Length; i++)                   //Shows stats for quarterback 
                    {
                        if (players[i].position == "Quarterback")
                        {
                            players[i].showStats();
                            Console.WriteLine();
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < players.Length; i++)                //Shows stats for running back   
                    {
                        if (players[i].position == "Running Back")
                        {
                            players[i].showStats();
                            Console.WriteLine();
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < players.Length; i++)               //shows stats for Wide Recievers
                    {
                        if (players[i].position == "Wide Receiver")
                        {
                            players[i].showStats();
                            Console.WriteLine();
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < players.Length; i++)               //shows stats for Linebackers
                    {
                        if (players[i].position == "Linebacker")
                        {
                            players[i].showStats();
                            Console.WriteLine();
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < players.Length; i++)               //shows stats for Defensive backs
                    {
                        if (players[i].position == "Defensive Back")
                        {
                            players[i].showStats();
                            Console.WriteLine();
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < players.Length; i++)               //shows stats for Offsensive Linemen
                    {
                        if (players[i].position == "Offensive Lineman")
                        {
                            players[i].showStats();
                            Console.WriteLine();
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i < players.Length; i++)               //shows stats of all players
                    {
                        players[i].showStats();
                        Console.WriteLine();
                    }
                    break;
                case 8:
                    Console.WriteLine(team);
                    break;
                default:
                    Console.WriteLine("Not a valid input, returning to game... Press any key to continue");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("Press any key to Continue...");
            Console.ReadKey();
        }

        public static void initPlayers(Players[] playerSet, bool[] numberFlags)           //sets all of the players stats
        {
            int playerNumber = 0;
            
            for (int i = 0; i < playerSet.Length; i++)
            {
                playerNumber = rng.Next(1, 100);
                while(numberFlags[playerNumber])          //Gets the random jersey numbers
                {
                    playerNumber = rng.Next(1, 100);
                }
                numberFlags[playerNumber] = true;
                playerSet[i] = new Players(playerNumber, rng.Next(0,101), rng.Next(0, 101), rng.Next(0, 101), rng.Next(0, 101), rng.Next(0, 101), rng.Next(50, 101));
            }
            assignPosition(playerSet);
        }

        public static void initTeams(Teams teamOne, Teams teamTwo,Players[] playerSetOne, Players[] playerSetTwo)    //Sets up teams by averging their players stats and giving them names
        {
            bool human = true;                                  //tells the method in the Teams class that this is a human player

            teamOne.nameTeam(human);
            teamOne.averageTeams(playerSetOne);
            human = false;
            teamTwo.nameTeam(human);
            teamTwo.averageTeams(playerSetTwo);
        }

        public static void assignPosition(Players[] playerSet)                   //automatically assigns player postions based on stats with some positions taking priority
        {
            bool[] playerFlags = new bool[22];     //Flags so player dont get chosen twice
            int highestStat = 0;                     //highest stat of player to determine who wins the position
            int chosenPlayer = 0;             //takes the array position of the player with the highest stat so they can be assigned
            for (int i = 0; i < 22; i++)
            { 
                if (playerSet[i].passing > highestStat)                                    //Goes through each player one at a time until best is chosen for that position
                {                                                                          //Some position take priority
                    highestStat = playerSet[i].passing;                                    //QB-1,RB-1,WR-4,LB-7,DB-4,OL-5  = 22
                    chosenPlayer = i;                               
                }
            }
            playerSet[chosenPlayer].position = "Quarterback";
            playerFlags[chosenPlayer] = true;
            highestStat = 0;

            for (int i = 0; i < 22; i++)
            {
                if ((playerSet[i].running > highestStat) && (playerFlags[i] == false))
                {
                    highestStat = playerSet[i].running;
                    chosenPlayer = i;
                }
            }
            playerSet[chosenPlayer].position = "Running Back";
            playerFlags[chosenPlayer] = true;
            highestStat = 0;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 22; i++)
                {
                    if ((playerSet[i].catching > highestStat) && (playerFlags[i] == false))
                    {
                        highestStat = playerSet[i].catching;
                        chosenPlayer = i;
                    }
                }
                playerSet[chosenPlayer].position = "Wide Receiver";
                playerFlags[chosenPlayer] = true;
                highestStat = 0;
            }

            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 22; i++)
                {
                    if ((playerSet[i].runDef > highestStat) && (playerFlags[i] == false))
                    {
                        highestStat = playerSet[i].runDef;
                        chosenPlayer = i;
                    }
                }
                playerSet[chosenPlayer].position = "Linebacker";
                playerFlags[chosenPlayer] = true;
                highestStat = 0;
            }

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 22; i++)
                {
                    if ((playerSet[i].passDef > highestStat) && (playerFlags[i] == false))
                    {
                        highestStat = playerSet[i].passDef;
                        chosenPlayer = i;
                    }
                }
                playerSet[chosenPlayer].position = "Defensive Back";
                playerFlags[chosenPlayer] = true;
                highestStat = 0;
            }
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 22; i++)
                {
                    if ((playerSet[i].blocking > highestStat) && (playerFlags[i] == false))
                    {
                        highestStat = playerSet[i].blocking;
                        chosenPlayer = i;
                    }
                }
                playerSet[chosenPlayer].position = "Offensive Lineman";
                playerFlags[chosenPlayer] = true;
                highestStat = 0;
            }
        }

        public static void coinFlip(Teams teamOne)
        {
            int choice = 0;
            int flip = 0;                  //tells whether it is a head or tail
            string coinFace = "";          //converts flip into this

            Console.WriteLine("Now for the coin flip");
            Console.WriteLine("Would you like heads[1] or tails [2]");
            choice = getInt();
            while((choice < 1) || (choice > 2))
            {
                Console.WriteLine("That is not a valid input try again...");
                choice = getInt();
            }

            if(choice == 1)
            {
                Console.Write("You chose heads... ");
            }
            else if (choice == 2)
            {
                Console.Write("You chose tails... ");
            }
            else
            {
                Console.WriteLine("This should not show up: Error in Program.coinFlip");
            }

            flip = rng.Next(1, 3);                //coin flip is here
            if(flip == 1) 
            {
                coinFace = "heads";
            }
            else
            {
                coinFace = "tails";
            }
            Console.WriteLine("It was " + coinFace + "!");
            if(choice == flip)
            {
                Console.WriteLine("You won the toss!");
                Console.WriteLine("Would you like to kick[1] or recieve[2]?");
                choice = getInt();
                while ((choice < 1) || (choice > 2))
                {
                    Console.WriteLine("That is not a valid input try again...");
                    choice = getInt();
                }
                if(choice == 1)
                {
                    Console.WriteLine("You chose to kick");
                    teamOne.isOff = false;
                }
                else
                {
                    Console.WriteLine("You chose to receive");
                    teamOne.isOff = true;
                }
            }
            else
            {
                Console.WriteLine("You lost the toss");
                Console.WriteLine("Your opponent chose to receive");
                teamOne.isOff = false;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }                                   //Determines who gets the ball

        public static void scoreBoard(Teams teamOne, Teams teamTwo)                  //Displays the teams, who has the ball, time left, yardLine, and yards until a first down
        {
            if (teamOne.isOff == true)
            {
                Console.WriteLine(teamOne.name + ": " + teamOne.score + "*                " + teamTwo.name + ": " + teamTwo.score);
            }
            else if (teamOne.isOff == false)
            {
                Console.WriteLine(teamOne.name + ": " + teamOne.score + "                " + teamTwo.name + ": " + teamTwo.score + "*");
            }
            else
            {
                Console.WriteLine("This should not show up Error: Program.scoreBoard");
            }

            if (down == 1)
            {
                Console.Write(down + "st down and " + yardsToGo);
            }
            else if (down == 2)
            {
                Console.Write(down + "nd down and " + yardsToGo);
            }
            else if (down == 3)
            {
                Console.Write(down + "rd down and " + yardsToGo);
            }
            else if (down == 4)
            {
                Console.Write(down + "th down and " + yardsToGo);
            }
            else
            {
                Console.Write("Error: Program.scoreBoard");
            }
            
            Console.WriteLine("               Time Left:" + time + "               " + fieldPosition + " yardLine");
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        public static void printResults(Teams teamOne, Teams teamTwo)
        {
            Console.Clear();
            scoreBoard(teamOne, teamTwo);
            if(teamOne.score > teamTwo.score)
            {
                Console.WriteLine("Congratulations you won!");
            }
            else if (teamOne.score < teamTwo.score)
            {
                Console.WriteLine("You lost.... try again...");
            }
            else
            {
                Console.WriteLine("Tie Game!");
            }
        }

        public static void pauseMenu(Players[] playerSetOne, Players[] playerSetTwo, Teams teamOne, Teams teamTwo)
        {
            int choice = 0;

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] View your teams stats");
            Console.WriteLine("[2] View your opponents stats");
            Console.WriteLine("[3] End Game");
            Console.WriteLine("[4] Exit");
            choice = getInt();
            switch (choice)
            {
                case 1:
                    showStats(playerSetOne, teamOne);
                    break;
                case 2:
                    showStats(playerSetTwo, teamTwo);
                    break;
                case 3:
                    time = 0;
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Not a valid input... Continuing with game");
                    break;
            }
        }

        public static void passBall(Teams offteam, Teams defTeam, bool passOrRun)
        {
            int totalRate = 0;
            int randomRate = 0;
            int adjustedPass = 0;
            int adjustedCatching = 0;
            int yardsGained = 0;
            bool passingPlay = true;                                //tell defence command if it is coming from the passing or running method
            bool allTheWay = false;                                 //Skips defence phase if player goes all the way

            adjustedPass = offteam.passingRate / 3;                         //"adjusted" is just divided by 3 to make everything close to 100 for easier math for adding yards
            adjustedCatching = offteam.catchingRate / 3;
            randomRate = rng.Next(0, 51);                               //0-50 just so even if team has bad stats they can still get a chance at good offense
            totalRate = adjustedPass + adjustedCatching + randomRate;   

            if (totalRate > 112)                                     
            {
                yardsGained = 100 - fieldPosition;
                allTheWay = true;
            }
            else if ((totalRate <= 112) && (totalRate > 100))
            {
                yardsGained = rng.Next(10, 50);
            }
            else if ((totalRate <= 100) && (totalRate > 95))
            {
                yardsGained = rng.Next(7, 15);
            }
            else if ((totalRate <= 95) && (totalRate > 85))
            {
                yardsGained = rng.Next(4, 11);
            }
            else if ((totalRate <= 85) && (totalRate > 80))
            {
                yardsGained = rng.Next(0, 6);
            }
            else
            {
                yardsGained = rng.Next(-5, 2);
            }

            if (!allTheWay)
            {
                yardsGained -= defencePlay(yardsGained, passOrRun, passingPlay, defTeam);
            }
            simplifyYards(yardsGained);
            Console.WriteLine("The offense gained " + yardsGained + " yards");
            Console.ReadKey();
        }

        public static void runBall(Teams offteam, Teams defTeam, bool passOrRun)
        {
            int totalRate = 0;
            int randomRate = 0;
            int yardsGained = 0;
            bool passingPlay = false;                                //tell defence command if it is coming from the passing or running method
            bool allTheWay = false;                                 //Skips defence phase if player goes all the way

            randomRate = rng.Next(0, 21);                              
            totalRate = offteam.runningRate + randomRate;

            if (totalRate > 112)                                    
            {
                yardsGained = 100 - fieldPosition;
                allTheWay = true;
            }
            else if ((totalRate <= 112) && (totalRate > 100))
            {
                yardsGained = rng.Next(10, 50);
            }
            else if ((totalRate <= 100) && (totalRate > 95))
            {
                yardsGained = rng.Next(7, 15);
            }
            else if ((totalRate <= 95) && (totalRate > 85))
            {
                yardsGained = rng.Next(4, 11);
            }
            else if ((totalRate <= 85) && (totalRate > 80))
            {
                yardsGained = rng.Next(0, 6);
            }
            else
            {
                yardsGained = rng.Next(-5, 2);
            }

            if (!allTheWay)
            {
                yardsGained -= defencePlay(yardsGained, passOrRun, passingPlay, defTeam);
            }
            simplifyYards(yardsGained);
            Console.WriteLine("The offense gained " + yardsGained + " yards");
            Console.ReadKey();
        }

        public static int defencePlay(int yardsGained, bool passOrRun, bool passingPlay, Teams defTeam)
        {
            int totalRate = 0;
            int randomRate = 0;
            int yardsTaken = 0;                       //Yards that are subtracted from the yardsGained

            randomRate = rng.Next(0, 21);
            if (passingPlay)
            {
                totalRate = defTeam.passDefRate + randomRate;
            }
            else
            {
                totalRate = defTeam.runDefRate + randomRate;
            }
            if(totalRate > 110)
            {
                yardsTaken = rng.Next(1, 6);
            }
            else if ((totalRate <= 110) || (totalRate > 100))
            {
                yardsTaken = rng.Next(0, 5);
            }
            else if ((totalRate <= 100) || (totalRate > 90))
            {
                yardsTaken = rng.Next(0, 5);
            }
            else if ((totalRate <= 90) || (totalRate > 80))
            {
                yardsTaken = rng.Next(0, 3);
            }
            else if ((totalRate <= 80) || (totalRate > 70))
            {
                yardsTaken = rng.Next(0, 2);
            }
            else
            {
                yardsTaken = rng.Next(0, 0);
            }

            //Below will determine is play was expected
            if ((passOrRun) && (passingPlay))
            {
                Console.WriteLine("The defence expected the pass!");
                yardsTaken += rng.Next(1, 4);
            }
            else if ((!passOrRun) && (!passingPlay))
            {
                Console.WriteLine("The defence expected the run!");
                yardsTaken += rng.Next(1, 4);
            }
            else
            {
                Console.WriteLine("The offense took advantage of the defence...");               //defence called the play wrong
                yardsTaken -= rng.Next(1, 4);
            }
            //Console.WriteLine("yards taken" + yardsTaken);
            return yardsTaken;
        }

        public static void simplifyYards(int yardsGained)       //Later version will simplify yards counting down to 1 after the 50 yard line
        {
            yardsToGo -= yardsGained;
            fieldPosition += yardsGained;
        }

        public static void determineTD(Teams teamOne, Teams teamTwo)                        //will determine touchdowns along with simplifying first downs and ball turnovers
        {
            if(fieldPosition > 99)
            {
                if(teamOne.isOff)
                {
                    teamOne.score += 7;
                    Console.WriteLine("Touchdown!! You scored!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    teamOne.isOff = false;
                    fieldPosition = 25;
                    down = 1;
                    yardsToGo = 10;
                }
                else
                {
                    teamTwo.score += 7;
                    Console.WriteLine("Touchdown... Your opponent scored...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    teamOne.isOff = true;
                    fieldPosition = 25;
                    down = 1;
                    yardsToGo = 10;
                }
            }
            if(yardsToGo < 1)
            {
                Console.WriteLine("FirstDown!");
                yardsToGo = 10;
                down = 1;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            if (down > 4)
            {
                Console.WriteLine("Turnover on downs....");
                if(teamOne.isOff)
                {
                    teamOne.isOff = false;
                }
                else
                {
                    teamOne.isOff = true;
                }
                yardsToGo = 10;
                down = 1;
                fieldPosition = 100 - fieldPosition;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
            time -= rng.Next(10, 26);
        }

        public static void playBall()
        {
            int choice = 0;                                       //used for the switchboards
            bool[] numberFlags = new bool[100];
            int defencePlay = 0;                                  //used in random to determine if CPU Def will pick run or pass
            bool passOrRun = false;                               //Pass = true    Run = false  
            bool isPlay = true;
            Teams teamOne = new Teams();
            Teams teamTwo = new Teams();
            Players[] playerSetOne = new Players[22];             //you and computers team
            Players[] playerSetTwo = new Players[22];
            initPlayers(playerSetOne,numberFlags);                //initializes players to random stats in an array
            initPlayers(playerSetTwo,numberFlags);

            printDirections();
            initTeams(teamOne, teamTwo, playerSetOne, playerSetTwo);                            //initalizes teams with the players and gives names to teams
            scoreBoard(teamOne, teamTwo);
            coinFlip(teamOne);

            while(time > 0)
            {
                scoreBoard(teamOne, teamTwo);
                isPlay = true;                                 //used so you can access pause menu and not have down and time increment
                defencePlay = rng.Next(1, 3);                  //will randomize the CPU's decision to run or pass or to expect it on DEF
                if (defencePlay == 1)
                {
                    passOrRun = true;
                }
                else
                {
                    passOrRun = false;
                }

                if (teamOne.isOff)
                {
                    Console.WriteLine("Would you like to: \n[1] Pass the ball \n[2] Run the ball \n[3]Pause");

                    choice = getInt();
                    switch(choice)
                    {
                        case 1:
                            passBall(teamOne, teamTwo, passOrRun);
                            break;
                        case 2:
                            runBall(teamOne, teamTwo, passOrRun);
                            break;
                        case 3:
                            pauseMenu(playerSetOne, playerSetTwo, teamOne, teamTwo);
                            isPlay = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input, try again...");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Are you expecting a: \n[1] Pass \n[2] Run \n[3] Pause");
                    choice = getInt();
                    switch (choice)
                    {
                        case 1:
                            passOrRun = true;
                            if (defencePlay == 1)
                            {
                                passBall(teamTwo, teamOne, passOrRun); 
                            }
                            else
                            {
                                runBall(teamTwo, teamOne, passOrRun);
                            }
                            break;
                        case 2:
                            passOrRun = false;
                            if (defencePlay == 1)
                            {
                                passBall(teamTwo, teamOne, passOrRun);
                            }
                            else
                            {
                                runBall(teamTwo, teamOne, passOrRun);
                            }
                            break;
                        case 3:
                            pauseMenu(playerSetOne, playerSetTwo, teamOne, teamTwo);
                            isPlay = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input, try again...");
                            Console.ReadLine();
                            break;
                    }
                }
                if (isPlay)
                {
                    down++;
                    determineTD(teamOne, teamTwo);
                }
                Console.Clear();
            }
            printResults(teamOne, teamTwo);
        }

        static void Main(string[] args)
        {
            rng = new Random();
            playBall();
        }
    }
}
