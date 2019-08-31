using System;
using System.Collections.Generic;
using System.IO;
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
        private static List<object> UnsortedListItem { get; set; } = new List<object>();
        

        #endregion

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
            FormatFileMethodExtension.GetValidFileFormat(fileFormat);

            using(var fileStream = (TextWriter) new StreamWriter(File.Open($"{filePath}{"/"}{fileName}{fileFormat}", isAppend ? FileMode.Append : FileMode.Create)))
            {
                UnsortedListItem.Add(text);


                foreach (var item in UnsortedListItem) {
                    fileStream.WriteLine(item);
                    SortingUnsortedData<object>(UnsortedListItem);
                }
                
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
        public static async void ReadTextFromTheFileAsync(string filename, FileFormatTypeExtension fileFormat, string filePath, string text)
        {
            await Task.Delay(TimeSpan.FromSeconds(0.5));
        }

        /// <summary>
        /// Display any text to the current screen.
        /// </summary>
        /// <param name="text">The text to display</param>
        public static void PrintTextCurrentScreen(string text)
        {
            Console.WriteLine(text);
        }
        
        /// <summary>
        /// Sorting the current unsorted data.
        /// </summary>
        /// <typeparam name="TResult">The type of data that we want to be sorted</typeparam>
        /// <param name="items">The item</param>
        /// <returns></returns>
        public static TResult SortingUnsortedData<TResult>(this List<TResult> items)
        {
            if (items.Count < 0)
            {
                Console.WriteLine("Can't find any specific data from the file to be sorted");
                return default(TResult);
            }

            items.Sort();

            PrintTextCurrentScreen(items.ToString());


            return default(TResult);
        }
        

    }
}
