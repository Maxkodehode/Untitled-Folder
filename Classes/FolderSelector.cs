using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public static class FolderSelector
{
    public static string SelectFolder()
    {
        //fancy OS checker
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return SelectFolderWindows();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return SelectFolderLinux();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) 
        {
            return SelectFolderMacOs();
        }
        else
        {
            Console.WriteLine("Sorry mate, i don't support your OS");
            return string.Empty;
        }
    }

// Because it is nice and DRY.
    private static string RunProcessAndGetOutput(ProcessStartInfo psi)
    {
        using (var process = Process.Start(psi)!)
        {
            string selectedPath = process.StandardOutput.ReadToEnd().Trim();
            process.WaitForExit();
            return selectedPath;
        }
    }


        private static string SelectFolderWindows()
    {
        // PowerShell command to launch the native FolderBrowserDialog
        string powershellCommand = 
            "Add-Type -AssemblyName System.Windows.Forms; " +
            "$browser = New-Object System.Windows.Forms.FolderBrowserDialog; " +
            "$browser.Description = 'Select a destination folder:'; " +
            "$null = $browser.ShowDialog(); " +
            "Write-Host $browser.SelectedPath";

        var psi = new ProcessStartInfo
        {
            FileName = "powershell",
            Arguments = $"-Command \"{powershellCommand}\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        return RunProcessAndGetOutput(psi);
    }



    private static string SelectFolderLinux()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "zenity",
            Arguments = "--file-selection --directory --title=\"Select a directory\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
        };
        return RunProcessAndGetOutput(psi);
    }


    private static string SelectFolderMacOs()
    {
    
        string appleScript = 
            "set folderPath to POSIX path of (choose folder with prompt \"Select a destination folder:\")\n" +
            "write folderPath";

        var psi = new ProcessStartInfo
        {
            FileName = "osascript",
            Arguments = "-s",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        return RunProcessAndGetOutput(psi); 
    }

}



