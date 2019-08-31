namespace SorterApp
{
    /// <summary>
    /// The file manager class to handles any manipulating data from files
    /// that's like read or write operation.
    /// </summary>
    public static class FileManager
    {
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

        }

        /// <summary>
        /// Display any text to the current screen.
        /// </summary>
        /// <param name="text">The text to display</param>
        public static void PrintTextCurrentScreen(string text)
        {

        }
    }
}
