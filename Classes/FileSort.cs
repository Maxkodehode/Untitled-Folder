using System;
using System.IO;

public class FileSorter
{
    // Source and destination paths
    private readonly string _sourcePath;
    private readonly string _destinationDirectory;

    public FileSorter(string sourcePath, string newDirectory)
    {
        // Initializing source and destination paths
        _sourcePath = sourcePath;
        _destinationDirectory = newDirectory;
    }

    // Main method to sort files into categorized folders
    public void SortFiles()
    {
        try
        {
            var filesToProcess = Directory.EnumerateFiles(_sourcePath);

            foreach (string filePath in filesToProcess)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath)
                    .Replace(" ", "_");
                string timestamp = DateTime.Now.ToString("'_'yyyy-MM-dd'_'HH-mm-ss");
                string extension = Path.GetExtension(filePath);
                string newFileName = $"{fileNameWithoutExtension}{timestamp}{extension}";

                // Skip files without an extension
                if (string.IsNullOrEmpty(newFileName))
                    continue;

                string folderName = extension.TrimStart('.').ToUpper();

                //--- Categorizing extensions into broader folder names
                switch (folderName)
                {
                    case "JPG":
                    case "WEBP":
                    case "PNG":
                    case "JPEG":
                    case "AVIF":

                        folderName = $"IMAGES/{folderName}";
                        break;

                    case "PDF":
                    case "TXT":
                    case "DOC":
                    case "DOCX":
                    case "XLS":
                    case "XLSX":
                    case "PPT":
                    case "PPTX":
                    case "RFT":
                    case "MD":
                    case "EPUB":

                        folderName = $"DOCUMENTS/{folderName}";
                        break;

                    case "MP4":
                    case "MOV":
                    case "WMV":
                    case "AVI":
                    case "MKV":
                    case "FLV":

                        folderName = "VIDEOS";
                        break;

                    case "MP3":
                    case "WAV":
                    case "FLAC":
                    case "M4A":
                    case "OGG":
                    case "WMA":

                        folderName = "AUDIO";
                        break;

                    case "EXE":
                    case "MSI":
                    case "DEB":
                    case "PKG":
                    case "DMG":

                        folderName = "INSTALLERS";
                        break;

                    case "OTF":
                    case "TTF":
                    case "WOFF":
                    case "WOFF2":
                    case "EOT":
                    case "PFA":
                    case "PFB":
                    case "FON":
                        folderName = "FONT_STYLE";
                        break;

                    case "CSS":
                        folderName = "CODE/CSS";
                        break;

                    case "HTML":
                        folderName = "CODE/HTML";
                        break;

                    case "JS":
                        folderName = "CODE/JAVASCRIPT";
                        break;

                    case "JSON":
                        folderName = "CODE/JSON";
                        break;

                    default:
                        break;
                }

                //Creating the path and the sub-directory.
                string destinationDir = Path.Combine(_destinationDirectory, folderName);

                if (!Directory.Exists(destinationDir))
                {
                    Directory.CreateDirectory(destinationDir);
                }

                //Getting the file name and checking for duplicate names and append a number to it, e.g. filename(2)

                string destinationPath = Path.Combine(destinationDir, newFileName);
                int counter = 1;

                while (File.Exists(destinationPath))
                { //{fileNameWithoutExtension}{timestamp}{extension}
                    string newNewFileName =
                        $"{fileNameWithoutExtension}{timestamp}({counter}){extension}";
                    destinationPath = Path.Combine(destinationDir, newNewFileName);
                    counter++;
                }

                //Moving the files into their designated directories
                File.Move(filePath, destinationPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
        }
    }
}
