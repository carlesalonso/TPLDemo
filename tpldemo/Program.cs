using System;


namespace tpldemo
{


    class Program
    {


        protected  static int OrigRow { get; set; }
        protected  static int OrigCol { get; set; }

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(OrigCol + x, OrigRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }



        protected static void MainMenu()
        {
            // Main menu
            Console.Clear();
            OrigRow = Console.CursorTop;
            OrigCol = Console.CursorLeft;
            var horizPos = 22;
            WriteAt("TPL demo", 33, 2);
            WriteAt("1 ....... Sequential For", horizPos, 4);
            WriteAt("2 ....... Parallel For", horizPos, 6);
            WriteAt("3 ....... Sequential LINQ", horizPos, 8);
            WriteAt("4 ....... Parallel LINQ", horizPos, 10);
            WriteAt("0 ....... EXIT PROGRAM", horizPos, 12);



        }


        static void Main(string[] args)
        {
            var demo = new Demos();
            Boolean exit = false;
            ConsoleKeyInfo option;

           
            while (!exit)
            {
                MainMenu();
                Console.CursorVisible = false;
                option = Console.ReadKey(true);
                bool showTime = true;

                switch (option.KeyChar)
                {
                    case '1':
                        WriteAt("Working......", 22, 16);
                        demo.SequentialFor();
                        break;
                    case '2':
                        WriteAt("Working......", 22, 16);
                        demo.ParallelFor();
                        break;
                    case '3':
                        WriteAt("Working......", 22, 16);
                        demo.Linq();
                        break;
                    case '4':
                        WriteAt("Working......", 22, 16);
                        demo.PLinq();
                        break;
                    case '0':
                        exit = true;
                        showTime = false; 
                        break;
                    default:
                        showTime = false;
                        break;

                }
                if (showTime)
                {
                    WriteAt($"{demo.TotalPrimesNumbers} primes numbers detected in {demo.EllapsedTime} ms ", 15, 16);
                    WriteAt("<Press any key to continue>", 22, 17);
                    Console.ReadKey();
                }
            }
        }
    }
}
