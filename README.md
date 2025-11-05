I want to create a file sorter for directories like "Downloads" which get fille with an asortment of files and file types.

To do this i first need to get the directory to sort and a directory to sort into.

To select directories, I want to use the built in Zenity's File/folder selection dialog GUI.

When both directories is selected i need to parse through the files and identify filetype.

For each unique filetype it creates a new sub-directory with the name of the filetype

I need to check if there are files with the same name in the sub-directory,
if there is i need to add, int i = 1; i++ fileName +"(" + (i) + ")"; fileName(i)


<img width="1998" height="1006" alt="image" src="https://github.com/user-attachments/assets/00232702-d014-42ed-80dc-47198947bb11" />



I ended up adding a switch statement to group image files, text files, audio files and video files into their own respective directories.

I also added a OS checker and it should now work on Windows.
