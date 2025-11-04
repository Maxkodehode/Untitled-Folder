using System;

class Program
{
    static void Main()
    {
        string selectedPath = FolderSelector.SelectFolder();
        
        if (!string.IsNullOrEmpty(selectedPath))
        {
            Console.WriteLine($"Selected: {selectedPath}");
            // Do your operations here
        }
        else
        {
            Console.WriteLine("No folder selected.");
        }
    }
}