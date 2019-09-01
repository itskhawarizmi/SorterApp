using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SorterApp
{
    /// <summary>
    /// The file manager class to handles any manipulating data from files
    /// that's like read or write operation.
    /// </summary>
    public static class FileManager
    {
        #region Properties

        /// <summary>
        /// The list to store any sorted data, from unsorted data.
        /// </summary>
        private static List<string> SortedListItem { get; set; }

        /// <summary>
        /// The list to store any unsorted data.
        /// </summary>
        private static List<string> UnsortedListItem { get; set; } = new List<string>();


        #endregion

        /// <summary>
        /// Resolve any relative element of the path to absolute path
        /// </summary>
        /// <param name="path">The path to resolve</param>
        /// <returns></returns>
        private static string ResolvePath(string filePath) => Path.GetFullPath(filePath);

        /// <summary>
        /// Normalizing a path based on the current operating systems like Windows,
        /// Linux, Mac etc.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string NormalizePath(string filePath) => filePath?.Replace('/', '\\').Trim();

        /// <summary>
        /// Writes some text to add to the file.
        /// </summary>
        /// <param name="fileName">The name of file</param>
        /// <param name="fileFormat">The format of the file</param>
        /// <param name="filePath">The location of file</param>
        /// <param name="isAppend">If true, indicates adding text to the end of file</param>
        /// <param name="text">The text to write to file</param>
        public static async void WriteTextToFileAsync(string fileName, FileFormatTypeExtension fileFormat, string filePath, bool isAppend, string text)
        {
            UnsortedListItem = new List<string>();

            try
            {

                // Check current path of our file
                filePath = NormalizePath(filePath);

                // And resolve path to get absolute 
                filePath = ResolvePath(filePath);


                using (var fileWriter = (TextWriter)new StreamWriter(File.Open($"{filePath}{"/"}{fileName}{FormatFileMethodExtension.GetValidFileFormat(fileFormat)}", isAppend ? FileMode.Append : FileMode.Create)))
                {
                    UnsortedListItem = text.Split(new char[] { ',', '.', '"', '/', '-', ';', ':', '\n', '\t' }).ToList();


                    foreach (var item in UnsortedListItem)
                        fileWriter.WriteLine(item);
                    

                    // By automatically the data from the list will be sorted
                    SortingUnsortedData<string>(UnsortedListItem);

                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Message: {Ex.Message}");
            }
          
           await Task.Delay(TimeSpan.FromSeconds(0.5));
        }

        /// <summary>
        /// Writes some text to add to the file.
        /// </summary>
        /// <param name="fileName">The name of file</param>
        /// <param name="fileFormat">The format of the file</param>
        /// <param name="filePath">The location of file</param>
        /// <param name="isAppend">If true, indicates adding text to the end of file</param>
        /// <param name="text">The text to write to file</param>
        public static async void WriteTextToFileAsync<T>(string fileName, FileFormatTypeExtension fileFormat, string filePath, bool isAppend, List<T> texts)
        {
            try
            {

                // Check current path of our file
                filePath = NormalizePath(filePath);

                // And resolve path to get absolute 
                filePath = ResolvePath(filePath);


                using (var fileWriter = (TextWriter)new StreamWriter(File.Open($"{filePath}{"/"}{fileName}{FormatFileMethodExtension.GetValidFileFormat(fileFormat)}", isAppend ? FileMode.Append : FileMode.Create)))
                {
                    if (texts.Count() <= 0)
                        return;

                    foreach (var item in texts)
                        fileWriter.WriteLine(item);


                    Console.WriteLine("Good job!, Your data has been written to the file successfully...");
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Message: {Ex.Message}");
            }

            await Task.Delay(TimeSpan.FromSeconds(0.5));
        }

        /// <summary>
        /// Reads all text from the file.
        /// </summary>
        /// <param name="fileName">The name of file</param>
        /// <param name="fileFormat">The format of the file</param>
        /// <param name="filePath">The location of file</param>
        /// <param name="text">The text to write to file</param>
        public static async void ReadTextFromTheFileAsync(string fileName, FileFormatTypeExtension fileFormat, string filePath)
        {
            try
            {
                SortedListItem = new List<string>();

                // Check current path of our file
                filePath = NormalizePath(filePath);

                // And resolve path to get absolute 
                filePath = ResolvePath(filePath);

                using (var fileReader = (TextReader)new StreamReader(File.Open($"{filePath}{"/"}{fileName}{FormatFileMethodExtension.GetValidFileFormat(fileFormat)}", FileMode.Open)))
                {
                    while (fileReader.Peek() >= 0)
                        UnsortedListItem.Add(fileReader.ReadLine());
                    

                    SortingUnsortedData<string>(UnsortedListItem);
                }

            }
            catch(Exception Ex)
            {
                Console.WriteLine($"Message: {Ex.Message}");
            }


            await Task.Delay(TimeSpan.FromSeconds(0.5));
        }

        /// <summary>
        /// Display any text to the current screen.
        /// </summary>
        /// <param name="text">The text to display</param>
        public static void PrintTextCurrentScreen(string text)
        {
            Console.WriteLine(text);

            Console.ReadLine();
        }

        /// <summary>
        /// Display any text to the current screen.
        /// </summary>
        /// <param name="items">The text to display</param>
        public static void PrintTextCurrentScreen<T>(List<T> items)
        {
            foreach (var item in items)
                Console.WriteLine(item.ToString());

            Console.WriteLine("Would you like to save this data to the file which stored data sorted? Y/N");
            Console.Write("->");
            var option = Console.ReadLine().Trim().ToUpper();

            if (option == "Y")
               WriteTextToFileAsync<string>("sorted-text-list", FileFormatTypeExtension.Text, @"D:\Git\SorterApp\SorterApp\SorterApp\FileTexts\", false, SortedListItem); 
            else
                Console.WriteLine("No command execute!..");

            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine(".......");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine(".........");
            
            
        }

        /// <summary>
        /// Sorting the current unsorted data.
        /// </summary>
        /// <typeparam name="TResult">The type of data that we want to be sorted</typeparam>
        /// <param name="items">The item</param>
        /// <returns></returns>
        public static void SortingUnsortedData<TResult>(this List<TResult> items)
        {
            SortedListItem = new List<string>();
            

            if (items.Count < 0)
            {
                Console.WriteLine("Can't find any specific data from the file to be sorted");
                return;
            }
            

            // Sorting any data from the list.
            items.Sort();

            foreach (var item in items)
                SortedListItem.Add(item.ToString());


            


            // Display to screen.
            PrintTextCurrentScreen(SortedListItem);
            
        }
        

    }
}
