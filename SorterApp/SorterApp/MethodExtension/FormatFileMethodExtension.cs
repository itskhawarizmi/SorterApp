using System.Diagnostics;

namespace SorterApp
{
    /// <summary>
    /// The class for handles to get specific format for file correctly.
    /// </summary>
    public static class FormatFileMethodExtension
    {
        /// <summary>
        /// Get valid format.
        /// </summary>
        /// <param name="type">The type of file format</param>
        /// <returns></returns>
        public static string GetValidFileFormat(FileFormatTypeExtension type)
        {
            switch (type)
            {
                case FileFormatTypeExtension.Text:
                    return ".txt";
                case FileFormatTypeExtension.Document:
                    return ".doc";
                case FileFormatTypeExtension.Pdf:
                    return ".pdf";
                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}
