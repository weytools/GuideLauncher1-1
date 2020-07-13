using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLauncher.Logic
{
    /// <summary>
    /// Methods related to finding a product guide based on a product number
    /// </summary>
    public static class ProductGuideLogic
    {
        /// <summary>
        /// Returns first 4 or 3 letters of product depending on first letter.
        /// </summary>
        /// <param name="productCaps"></param>
        /// <returns>3 or 4 letter grade</returns>
        public static string ExtractGrade(string productName)
        {

            string productCaps = productName.ToUpper();

            char firstChar = productCaps[0];
            char secondChar = productCaps[1];

            // E28 & P28 grades
            if (Char.IsNumber(secondChar))

                return productCaps.Substring(0, 3);

            // E, N, P grades
            else if (firstChar == 'E' || firstChar == 'N' || firstChar == 'P')

                return productCaps.Substring(0, 4);

            // all other grades
            else
                return productCaps.Substring(0, 3);
        }

        /// <summary>
        /// finds a matching product guide file and returns the path
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>product guide file path</returns>
        public static string GetPath(string grade)
        {
            // get the top folder
            string gradeFolder = GetTopFolder(grade);

            // check we found a folder
            if (gradeFolder == string.Empty)
                return string.Empty;

            // search for the matching pdf
            string[] matchingGuide = Directory.GetFiles(gradeFolder, $"{grade}*");

            // if none found
            if (matchingGuide.Length == 0)
                return string.Empty;

            // if multiples found
            if (matchingGuide.Length > 1)
                ErrorMultipleFound();

            return matchingGuide[0];
        }


        /// <summary>
        /// Error message if none found
        /// </summary>
        public static void ErrorNoneFound()
        {
            System.Windows.MessageBox.Show("No matching guide was found.",
                "None Found",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Exclamation);
        }
        /// <summary>
        /// Error message if multiples found
        /// </summary>
        public static void ErrorMultipleFound()
        {
            System.Windows.MessageBox.Show("More than 1 matching guide was found!",
                "Warning!",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Error message if too short entry
        /// </summary>
        public static void ErrorTooShort()
        {
            System.Windows.MessageBox.Show("Entries need to be at least 3 characters long",
                "Warning!",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Searches the network for the matching folder containing the product guide
        /// </summary>
        /// <param name="grade">3 or 4 letter grade</param>
        /// <returns>Full file path for the folder containing the product guide</returns>
        private static string GetTopFolder(string grade)
        {
            // get first letter
            char category = Char.ToUpper(grade[0]);
            string folderSearch = $"_{category}*";

            // find matching folder
            string workingPath = @"\\filesrv\Product Guides\";
            string[] topFolder = Directory.GetDirectories(workingPath, folderSearch);

            // special case for N grades
            if (category == 'N')
                return @"\\filesrv\Product Guides\NXXX PRODUCTS";

            // if none found
            if (topFolder.Length == 0)
                return string.Empty;

            return topFolder[0];
        }

        /// <summary>
        /// returns the name of the file
        /// </summary>
        public static string GetTitle(string path)
        {
            return System.IO.Path.GetFileName(path);
        }
    }
}
