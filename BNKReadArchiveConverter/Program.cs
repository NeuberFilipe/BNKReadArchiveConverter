using System;
using System.IO;

namespace BNKReadArchiveConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadDirectoryConvertArchiveTXT();
            ReadArchiveTXT();
        }

        #region Methods
        private static void ReadArchiveTXT()
        {
            string[] lines = File.ReadAllLines(@"XXXXXXXX");
            string repoResult = @"XXXXXXXX";
            StreamWriter stream;

            foreach (var line in lines)
            {
                //Developed to meet the logic
                if (line.Length > 7)
                    continue;

                stream = File.AppendText(repoResult);
                stream.WriteLine($"{line}");
                stream.Close();
            }
        }

        private static void ReadDirectoryConvertArchiveTXT()
        {
            DirectoryInfo dir = new DirectoryInfo(@"XXXXXXXX");
            string repolocal = @"XXXXXXXX";
            StreamWriter stream;
            FileInfo[] files = dir
                                .GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo file in files)
            {
                string filename = file
                    .FullName
                    .Replace(dir.FullName + "\\", "")
                    .Replace(".pdf", "")
                    .Replace("GED_", "");

                //Developed to meet the logic
                if (TryParseGuid(filename))
                    continue;

                stream = File.AppendText(repolocal);
                stream.WriteLine($"{filename}");
                stream.Close();
            }
        }

        public static bool TryParseGuid(string guidString)
        {
            if (guidString == null) throw new ArgumentNullException("guidString");
            try
            {
                new Guid(guidString);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        } 
        #endregion
    }
}
