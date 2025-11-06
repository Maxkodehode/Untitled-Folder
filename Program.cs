using System;
using System.Runtime.InteropServices;

class Program
{
    // Main entry point of the application
    static void Main()
    {
        // Prompt user to select source and destination folders
    Console.WriteLine("Please select the source folder:");
        string selectedPath = FolderSelector.SelectFolder();
    
    Console.WriteLine("Please select the destination folder:");
        string newDirectory = FolderSelector.SelectFolder();


    // Proceed only if both paths are valid
    if (!string.IsNullOrEmpty(selectedPath) && !string.IsNullOrEmpty(newDirectory))
        {
        Console.WriteLine($"\nSource Selected: {selectedPath}");
        Console.WriteLine($"Destination Selected: {newDirectory}");    

        FileSorter sorter = new FileSorter(selectedPath, newDirectory);
        Console.WriteLine($"Starting from the '{selectedPath}' to destination folder in '{newDirectory}'...");
        sorter.SortFiles();    
        }
    
    else
        {
            // Inform user about cancellation or missing dependencies
        Console.WriteLine("\n--- Directory Selection Status ---\n");
        Console.WriteLine("Selection was canceled, or the Zenity dependency is missing.");


        Console.WriteLine("\nIf you are certain you did not cancel, please install Zenity using the appropriate command for your Linux distribution:\n");
        Console.WriteLine("Use the appropriate command for your Linux distribution:\n" +
        
        "----------------------------------------------------\n" +
        "1. Debian/Ubuntu/Mint (APT):\n" +
        "   sudo apt update\n" +
        "   sudo apt install zenity\n\n" +
        "2. Fedora/RHEL/CentOS (DNF):\n" +
        "   sudo dnf install zenity\n\n" +
        "3. Arch Linux (Pacman):\n" +
        "   sudo pacman -S zenity\n\n" +
        "4. openSUSE (Zypper):\n" +
        "   sudo zypper install zenity\n" +
        "----------------------------------------------------");
        }
    }
}
