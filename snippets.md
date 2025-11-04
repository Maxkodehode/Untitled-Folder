using System;
using Gtk;

class Program
{
static void Main()
{
Application.Init();

        var fileChooser = new FileChooserDialog(
            "Select a directory",
            null,
            FileChooserAction.SelectFolder,
            "Cancel", ResponseType.Cancel,
            "Select", ResponseType.Accept
        );

        if (fileChooser.Run() == (int)ResponseType.Accept)
        {
            Console.WriteLine($"Selected: {fileChooser.Filename}");
        }

        fileChooser.Destroy();
    }

}
