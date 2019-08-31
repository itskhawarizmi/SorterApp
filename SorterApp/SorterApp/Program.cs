using System;
using System.Threading;

namespace SorterApp
{
    /// <summary>
    /// The main class our program.
    /// </summary>
    class Program
    {
        #region Properties

        /// <summary>
        /// The boolean value for handle any loop in our program
        /// if true, program should be terminated.
        /// </summary>
        private static bool BreakLoop { get; set; } = true;

        /// <summary>
        /// The name of files.
        /// </summary>
        private static string FileName = string.Empty;

        /// <summary>
        /// The location of files.
        /// </summary>
        private static string FilePath = string.Empty;

        /// <summary>
        /// The format of the file. Make sure we have 
        /// set the file format correctly
        /// </summary>
        private static string FileFormat = ".txt";

        /// <summary>
        /// The text we want to add to the file.
        /// </summary>
        private static string FileText =string.Empty;

        /// <summary>
        /// If true, indicates adding text to end of file.
        /// </summary>
        private static bool IsAppend = false; 

        #endregion


        /// <summary>
        /// The main method our program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Private Members
            
            string option = string.Empty;

            #endregion

            do
            {
                Console.Clear();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("Loading.....");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.Clear();


                Console.WriteLine("SorterApp - Sorting any value what you want it");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1. Writes some text to files");
                Console.WriteLine("2. Reads some text from files");
                Console.WriteLine("3. Exit");
                Console.Write("Please type your required option [1 / 2 / 3]:   ");
                option = Console.ReadLine();
                UserOptionExecute(option);

            } while (BreakLoop);
            
        }

        /// <summary>
        /// Execute any order from user option that's selected.
        /// </summary>
        /// <param name="option"></param>
        static void UserOptionExecute(string option)
        {
            switch (option)
            {
                // Writes text to file
                case "1":
                    Console.Clear();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine("Loading.....");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.Clear();

                    // location file / path
                    Console.WriteLine("Type the location of the file you want to save....");
                    Console.Write("->");
                    FilePath = Console.ReadLine();
                    // file name
                    Console.WriteLine("Type the name of the file you want to save....");
                    Console.Write("->");
                    FileName = Console.ReadLine();
                    // add text to the end of file
                    Console.WriteLine("Do you want add the text to the of file ? true / false");
                    Console.Write("->");
                    IsAppend = Convert.ToBoolean(Console.ReadLine());
                    // add text to the file
                    Console.WriteLine("Type the text you want to add to the file");
                    Console.Write("->");
                    FileText = Console.ReadLine();
                    FileManager.WriteTextToFileAsync(FileName, FileFormatTypeExtension.Text, FilePath, IsAppend, FileText);

                    break;

                // Reads text from file
                case "2":
                    Console.Clear();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine("Loading.....");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.Clear();

                    // location file / path
                    Console.WriteLine("Type the location of the file you want to read....");
                    Console.Write("->");
                    FilePath = Console.ReadLine();
                    // file name
                    Console.WriteLine("Type the name of the file you want to read....");
                    Console.Write("->");
                    FileName = Console.ReadLine();
                    FileManager.ReadTextFromTheFileAsync(FileName, FileFormatTypeExtension.Text, FilePath);
                    break;
   
                // Close program        
                case "3":
                    Console.WriteLine("Thanks... See you latter..");
                    BreakLoop = false;
                    break;

                default:
                    break;
            }
        }
    }
}
