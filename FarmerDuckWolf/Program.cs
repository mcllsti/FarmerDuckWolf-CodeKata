using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Media;

namespace FarmerDuckWolf
{
     class Program
    {
        public static Duck duckie = new Duck("Duckie", "Left Bank", true, "Corn", false, false);
        public static Boat boat = new Boat("Boat", "Left Bank", "Wood");
        public static Farmer farmer = new Farmer("John", "Left Bank", false, "Pie", true);
        public static Corn corn = new Corn("Corn", "Left Bank", true, "1 bag");
        public static Wolf wolf = new Wolf("Wolfie", "Left Bank", false, "Duck", true);
        public static List<object> leftBank = new List<object>() { boat, farmer, duckie, wolf, corn };
        public static List<object> rightBank = new List<object>();



        static void Main(string[] args)
        {


            StartScreen();

        }

        static void ConsoleDraw(IEnumerable<string> lines, int x, int y)
        {
            if (x > Console.WindowWidth) return;
            if (y > (Console.WindowHeight/4)) return;

            var trimLeft = x < 0 ? -x : 0;
            int index = y;

            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;

            var linesToPrint =
                from line in lines
                let currentIndex = index++
                where currentIndex > 0 && currentIndex < Console.WindowHeight
                select new
                {
                    Text = new String(line.Skip(trimLeft).Take(Math.Min(Console.WindowWidth - x, line.Length - trimLeft)).ToArray()),
                    X = x,
                    Y = y++
                };

            Console.Clear();
            foreach (var line in linesToPrint)
            {
                Console.SetCursorPosition(line.X, line.Y);
                Console.Write(line.Text);
            }
        }


        static void PlayArea()
        {
            string userInput;
            Console.WriteLine("play here");
            Console.WriteLine("-------------");
            Console.WriteLine(" ");
            userInput = Console.ReadLine();
            Console.WriteLine(" ");
            char seperatingChar = ' ';
            string[] words = userInput.Split(seperatingChar);

            if(words.Length<2 && words.Length>3)
            {
                Console.WriteLine("Command not recognised");
            }
            else
            {
                for(int i = 0;i<words.Length;i++)
                {
                    words[i] = words[i].ToUpper();
                }

                FirstCheck(words);
            }
            Console.ReadLine();

        }

        static void FirstCheck(string[] words)
        {

            switch (words[0])
            {
                case "FARMER":
                    
                    FarmerCommands(words);
                    break;
                case "WOLF":
                    WolfCommands(words);
                    break;
                case "DUCK":
                    DuckCommands(words);
                    break;
                case "CORN":
                    CornCommands(words);
                    break;
                case "SET":
                    CornCommands(words);
                    break;
                case "GET":
                    CornCommands(words);
                    break;
                default:
                    Console.WriteLine("That command is not recognised");
                    break;
            }
        }

        static void FarmerCommands(string[] words)
        {
            char choice = 'n';
            switch (words[1])
            {
                case "GET-IN":
                    choice = 'f';
                    GetInCommand(words, choice);
                    break;
                case "KICK":
                    WolfCommands(words);
                    break;
                case "DRINK":
                    DuckCommands(words);
                    break;
                case "HIT":
                    CornCommands(words);
                    break;
                case "SWIM":
                    CornCommands(words);
                    break;
                case "EAT":
                    CornCommands(words);
                    break;
                case "ROW":
                    CornCommands(words);
                    break;
                case "GET-OUT":
                    GetOutCommand(words,choice);
                    break;
                default:
                    Console.WriteLine("That command is not recognised");
                    break;
            }
        }

        static void WolfCommands(string[] words)
        {
            char choice = 'n';
            switch (words[1])
            {
                case "GET-IN":
                    choice = 'w';
                    GetInCommand(words, choice);
                    break;
                case "DRINK":
                    DuckCommands(words);
                    break;
                case "BITE":
                    CornCommands(words);
                    break;
                case "SWIM":
                    CornCommands(words);
                    break;
                case "EAT":
                    CornCommands(words);
                    break;
                case "BARK":
                    CornCommands(words);
                    break;
                case "GET-OUT":
                    GetOutCommand(words, choice);
                    break;
                default:
                    Console.WriteLine("That command is not recognised");
                    break;
            }
        }

        static void DuckCommands(string[] words)
        {
            char choice = 'n';
            switch (words[1])
            {
                case "GET-IN":
                    choice = 'd';
                    GetInCommand(words, choice);
                    break;
                case "DRINK":
                    DuckCommands(words);
                    break;
                case "BITE":
                    CornCommands(words);
                    break;
                case "SWIM":
                    CornCommands(words);
                    break;
                case "EAT":
                    CornCommands(words);
                    break;
                case "QUACK":
                    CornCommands(words);
                    break;
                case "GET-OUT":
                    GetOutCommand(words, choice);
                    break;
                default:
                    Console.WriteLine("That command is not recognised");
                    break;
            }
        }

        static void CornCommands(string[] words)
        {
            char choice = 'n';
            switch (words[1])
            {
                case "GET-IN":
                    choice = 'c';
                    GetInCommand(words, choice);
                    break;
                case "GET-OUT":
                    GetOutCommand(words, choice);
                    break;
                default:
                    Console.WriteLine("That command is not recognised");
                    break;
            }
        }

        static void GetInCommand(string[] words, char choice)
        {
            if (words.Length == 3)
            {
                if (words[2].Equals("BOAT"))
                {
                    switch (choice)
                    {
                        case 'f':
                            GetInBoat(farmer);
                            break;
                        case 'w':
                            GetInBoat(wolf);
                            break;
                        case 'd':
                            GetInBoat(duckie);
                            break;
                        case 'c':
                            GetInBoat(corn);
                            break;
                        default:
                            Console.WriteLine("That command is not recognised");
                            break;
                    }
                }
                else if (words[2].Equals("RIVER") || words[2].Equals("WATER") || words[2].Equals("LAKE"))
                {
                    switch (choice)
                    {
                        case 'f':
                            Console.WriteLine(farmer.Name + " gets in the river.");
                            Console.WriteLine(farmer.Name + " feels something moveing. Before " + farmer.Name + " can get out," + farmer.Name + " is devoured by piranhas");
                            Console.ReadLine();
                            DeathScreen();
                            break;
                        case 'w':
                            Console.WriteLine(wolf.Name + " gets in the river.");
                            Console.WriteLine(wolf.Name + " can see a stick at the bottom of the river." + wolf.Name + " drowns trying to fetch the stick.");
                            Console.ReadLine();
                            DeathScreen();
                            break;
                        case 'd':
                            if(duckie.CanSwim)
                            {
                                Console.WriteLine(duckie.Name +" gets in the river.");
                                Console.WriteLine(duckie.Name + " starts swimming across.");
                                Console.WriteLine(duckie.Name + " gets half way and is eaten by a alligator");
                                Console.ReadLine();
                                DeathScreen();
                            }
                            else
                            {
                                Console.WriteLine(duckie.Name + " gets in the river.");
                                Console.WriteLine(duckie.Name + " was raised by chickens and never learned to swim.");
                                Console.WriteLine(duckie.Name + " drowns");
                                Console.ReadLine();
                                DeathScreen();
                            }
                            break;
                        case 'c':
                            Console.WriteLine("The corn is helped into the water by " + farmer.Name);
                            Console.WriteLine("The corn sinks to the bottom of the river.");
                            Console.WriteLine("I dont know what you expected.");
                            Console.ReadLine();
                            FailScreen();
                            break;
                        default:
                            Console.WriteLine("That command is not recognised");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("That command is not recognised");
                }
            }
            else
            {
                Console.WriteLine("That command is not recognised");
            }


        }

        static void GetOutCommand(string[] words, char choice)
        {
            if (words.Length == 3)
            {
                if (words[2].Equals("BOAT"))
                {
                    GetOutBoat();

                }
                else
                {
                    Console.WriteLine("That command is not recognised");
                }
            }
            else
            {
                Console.WriteLine("That command is not recognised");
            }


        }


        static void DisplayInstructions()
        {
            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\PuzzleTheme1.wav";
            //player.PlayLooping();

            Console.Clear();
            string[] instructions = new string[6];
            instructions[0] = "A farmer with his wolf, duck and bag of corn come to the left bank of a river \n that they wish to cross.";
            instructions[1] = "There is a boat at the rivers edge but of course only the farmer can row";
            instructions[2] = "The boat can only hold two things, including the farmer, at any one time";
            instructions[3] = "If the wolf is ever left alone with the duck, the wolf will eat it";
            instructions[4] = "Similary if the duck is ever left alone with the corn, the duck will eat it";
            instructions[5] = "How can the farmer get across the river so that all four arrive saflet on the other side?";

            foreach ( string inst in instructions)
            {
                Console.WriteLine(inst);
                Thread.Sleep(1200);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Type 'Start' to continue!");
            string cont = Console.ReadLine();
            if (cont.Equals("Start") || cont.Equals("start"))
            {
                Console.Clear();
                PlayArea();
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("You did not type Start! Guess you dont want to play...");
                Console.ReadLine();
                FailScreen();
            }
            


        }



        static void Reset()
        {
            duckie.Name = "Duckie";
            duckie.Side = "Left Bank";
            duckie.IsHungry = true;
            duckie.FavFood = "Corn";
            duckie.CanRow = false;
            duckie.CanSwim = false;

            boat.Name = "Boat";
            boat.Side = "Left Bank";
            boat.MadeOf = "Wood";
            boat.Reset();

            farmer.Name = "John";
            farmer.Side = "Left Bank";
            farmer.IsHungry = false;
            farmer.FavFood = "Pie";
            farmer.CanRow = true;

            wolf.Name = "Wolfie";
            wolf.Side = "Left Bank";
            wolf.IsHungry = true;
            wolf.FavFood = "Duck";
            wolf.CanRow = false;

            corn.Name = "Corn";
            corn.Side = "Left Bank";
            corn.IsDelicious = true;
            corn.HowMuch = "1 Bag";

            leftBank.Clear();
            rightBank.Clear();
            leftBank.Add(boat);
            leftBank.Add(farmer);
            leftBank.Add(duckie);
            leftBank.Add(corn);
            leftBank.Add(wolf);

        }



        static void WinGame()
        {
            if(rightBank.Contains(duckie) && rightBank.Contains(farmer) && rightBank.Contains(wolf) && rightBank.Contains(corn))
            {
                WinScreen();
            }
            else
            {
                return;
            }
        }

        static void WinScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var arr = new[]
{
                    @" __     ______  _    _  __          _______ _   _ _ ",
                    @" \ \   / / __ \| |  | | \ \        / /_   _| \ | | |",
                    @"  \ \_/ / |  | | |  | |  \ \  /\  / /  | | |  \| | |",
                    @"   \   /| |  | | |  | |   \ \/  \/ /   | | | . ` | |",
                    @"    | | | |__| | |__| |    \  /\  /   _| |_| |\  |_|",
                    @"    |_|  \____/ \____/      \/  \/   |_____|_| \_(_)",
                    @"                                                    ",
                    @"                     WELL DONE!                    ",
            };
            DisplayScreens(arr);
        }

        static void FailScreen()
        {
            Console.Clear();
            var arr = new[]
{
                    @" __     ______  _    _   ______      _____ _      _ ",
                    @" \ \   / / __ \| |  | | |  ____/\   |_   _| |    | |",
                    @"  \ \_/ / |  | | |  | | | |__ /  \    | | | |    | |",
                    @"   \   /| |  | | |  | | |  __/ /\ \   | | | |    | |",
                    @"    | | | |__| | |__| | | | / ____ \ _| |_| |____|_|",
                    @"    |_|  \____/ \____/  |_|/_/    \_\_____|______(_)",
                    @"                                                    ",
                    @"             Press Enter To Restart                 ",
            };

            DisplayScreens(arr);

        }

        static void DisplayScreens(string[] arr)
        {
            Console.WriteLine("\n\n");
            foreach (string line in arr)
                Console.WriteLine(line);
            Console.ResetColor();
            Console.ReadKey();
            DisplayInstructions();
        }

        static void DeathScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            var arr = new[]
{
                    @" __     ______  _    _   _____ _____ ______ _____  _ ",
                    @" \ \   / / __ \| |  | | |  __ \_   _|  ____|  __ \| |",
                    @"  \ \_/ / |  | | |  | | | |  | || | | |__  | |  | | |",
                    @"   \   /| |  | | |  | | | |  | || | |  __| | |  | | |",
                    @"    | | | |__| | |__| | | |__| || |_| |____| |__| |_|",
                    @"    |_|  \____/ \____/  |_____/_____|______|_____/(_)",
            };
            DisplayScreens(arr);
        }

        static void StartScreen()
        {
            Console.Clear();
            Console.WindowWidth = 90;//((arr.Last().Length)+1);
            Console.WindowHeight = 40;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\WelcomeScreen.wav";
            //player.PlayLooping();

            Console.CursorVisible = false;

            var arr = new[]
            {
                    @"  _____   _                     _____                         ",
                    @" |  __ \ (_)                   / ____|                        ",
                    @" | |__) | _ __   __ ___  _ __ | |      _ __  ___   ___  ___   ",
                    @" |  _  / | |\ \ / // _ \| '__|| |     | '__|/ _ \ / __|/ __|  ",
                    @" | | \ \ | | \ V /|  __/| |   | |____ | |  | (_) |\__ \\__ \  ",
                    @" |_|  \_\|_|  \_/  \___||_|    \_____||_|   \___/ |___/|___/  ",
                    @"                                                              ",
                    @"                            .                                 ",
                    @"                          ~~|\                                ",
                    @"                          / | \                               ",
                    @"                         /  |  \                              ",
                    @"                        /   |   \                             ",
                    @"                       /    |    \                            ",
                    @"                      /_____| ____\                           ",
                    @"                      _____,======.--                         ",
                    @"                     (___________/                            ",
                    @"                  ~~~~~~~~~~~~~~~~~~~~~                       ",
                    @"                                                              ",
                    @"                Press Enter To Start The Game!                ",
        };

            var maxLength = arr.Aggregate(0, (max, line) => Math.Max(max, line.Length));
            var x = Console.BufferWidth / 2 - maxLength / 2;
            for (int y = -arr.Length; y < Console.WindowHeight + arr.Length; y++)
            {

                    ConsoleDraw(arr, x, y);
                    Thread.Sleep(50);

            }
            Console.ReadKey(true);
            Console.ResetColor();
            //player.Stop();
            DisplayInstructions();
        }

        static void GetInBoat(object TObject)
        {
            if (boat.Side.Equals("Left Bank"))
            {
                if (TObject is Farmer)
                {
                    boat.addBoat(farmer);
                    leftBank.Remove(farmer);
                    farmer.Side = "Boat";
                }
                else if (TObject is Duck)
                {
                    boat.addBoat(duckie);
                    leftBank.Remove(duckie);
                    duckie.Side = "Boat";
                }
                else if (TObject is Wolf)
                {
                    boat.addBoat(wolf);
                    leftBank.Remove(wolf);
                    wolf.Side = "Boat";
                }
                else
                {
                    boat.addBoat(corn);
                    leftBank.Remove(corn);
                    corn.Side = "Boat";
                }
            }
            else
            {
                if (TObject is Farmer)
                {
                    boat.addBoat(farmer);
                    rightBank.Remove(farmer);
                    farmer.Side = "Boat";
                }
                else if (TObject is Duck)
                {
                    boat.addBoat(duckie);
                    rightBank.Remove(duckie);
                    duckie.Side = "Boat";
                }
                else if (TObject is Wolf)
                {
                    boat.addBoat(wolf);
                    rightBank.Remove(wolf);
                    wolf.Side = "Boat";
                }
                else
                {
                    boat.addBoat(corn);
                    rightBank.Remove(corn);
                    corn.Side = "Boat";
                }
            }
        }



        static void GetOutBoat()
        {


            object TObject = boat.removeBoat();
            if(boat.Side.Equals("Left Bank"))
            {
                if (TObject is Farmer)
                {
                    leftBank.Add(farmer);
                    farmer.Side = "Left Bank";
                }
                else if (TObject is Duck)
                {
                    leftBank.Add(duckie);
                    duckie.Side = "Left Bank";
                }
                else if (TObject is Wolf)
                {
                    leftBank.Add(wolf);
                    wolf.Side = "Left Bank";
                }
                else
                {
                    leftBank.Add(corn);
                    corn.Side = "Left Bank";
                }
            }
            else
            {
                if (TObject is Farmer)
                {
                    rightBank.Add(farmer);
                    farmer.Side = "Right Bank";
                }
                else if (TObject is Duck)
                {
                    rightBank.Add(duckie);
                    duckie.Side = "Right Bank";
                }
                else if (TObject is Wolf)
                {
                    rightBank.Add(wolf);
                    wolf.Side = "Right Bank";
                }
                else
                {
                    rightBank.Add(corn);
                    corn.Side = "Right Bank";
                }
            }
            WinGame();
        }

        static void Row()
        {
            if(leftBank.Contains(boat))
            {
                rightBank.Add(boat);
                leftBank.Remove(boat);
                boat.Side = "Right Bank";
                Console.WriteLine("The boat rows from the left bank to the right");
            }
            else
            {
                leftBank.Add(boat);
                rightBank.Remove(boat);
                boat.Side = "Left Bank";
                Console.WriteLine("The boat rows from the right bank to the left");
            }
        }

        static void HardcodedSolution()
        {
            GetInBoat(farmer);
            GetInBoat(duckie);
            duckie.quack();
            Row();
            GetOutBoat();
            Row();
            GetInBoat(corn);
            Row();
            GetOutBoat();
            GetInBoat(duckie);
            Row();
            GetOutBoat();
            GetInBoat(wolf);
            Row();
            GetOutBoat();
            Row();
            GetInBoat(duckie);
            Row();
            GetOutBoat();
            GetOutBoat();
            Console.WriteLine("--------------");
            Console.WriteLine(" ");
            Console.WriteLine("The number of people on the Left Bank is: " + leftBank.Count + " : ");
            leftBank.ForEach(Console.WriteLine);
            Console.WriteLine(" ");
            Console.WriteLine("--------------");
            Console.WriteLine("The number of people on the Left Bank is: " + rightBank.Count + " : ");
            foreach (object temp in rightBank)
            {
                Console.WriteLine(temp.ToString());
            }

            Console.ReadLine();
        }




    }
}
