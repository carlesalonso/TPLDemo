using System;


namespace tpldemo
{


   






    class Program
    {


        protected static int origRow;
        protected static int origCol;

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
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
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
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
            string timeEllapsed=null;
            double nPrimes;
            while (!exit)
            {
                MainMenu();
                Console.CursorVisible = false;
                do
                {
                    option = Console.ReadKey(true);
                } while (option.KeyChar < '0' || option.KeyChar > '5');
                bool showTime = true;


                switch (option.KeyChar)
                {
                    case '1':
                        WriteAt("Calculando......", 22, 16);
                        timeEllapsed = demo.SequentialFor(out nPrimes);
                        break;
                    case '2':
                        WriteAt("Calculando......", 22, 16);
                        timeEllapsed = demo.ParallelFor(out nPrimes);
                        break;
                    case '3':
                        WriteAt("Calculando......", 22, 16);
                        timeEllapsed = demo.Linq(out nPrimes);
                        break;
                    case '4':
                        WriteAt("Calculando......", 22, 16);
                        timeEllapsed = demo.PLinq(out nPrimes);
                        break;
                    case '0':
                        WriteAt("Calculando......", 22, 16);
                        exit = true;
                        showTime = false; 
                        break;
                    

                }
                if (showTime)
                {
                    WriteAt($"Ellapsed time {timeEllapsed}ms <Press a key>", 22, 16);
                    Console.ReadKey();
                }
            }
        }
    }
}
