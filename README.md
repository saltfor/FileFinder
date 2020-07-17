# FileFinder
It can find your same files in your computer

-GUI-
In graphical user interface, I added 3 button,3 listbox and 1 label.
‘Choose Directory’ button opens a folder browse dialog for choosing directory.
‘Start for Searching’ button performs to show filename, filesize,filelocation on the listboxes.
‘Save Results to XML’ button performs to save datas to XML from list boxes.
‘ListBoxes’ are showing the file informations.
‘Label’ is showing the choosing directory.

-Code Explanations-
‘Choose Directory’ Click
It opens browser dialog for choosing directory. If user choose folder and click OK then take path to variable. Change label text to directory. Disable this button and enable start button. Call the DirSearch method.
‘DirSearch’
This method take directory as input. Then it finds all subdirectories in main directory. Also its finds all file in all subdirectory. Then save the count of files. Also add the file informations to Arraylists and lists. This method call itself again because of we need to find all files in all directories.
‘Start for Searching’ Click
Disable this button. I used Buble Search algorithm in this method. If the same file name and size found, then add file informations to listboxes. Need to know old file. So I made “-“ instead of found filename. Because I checked this for versus. If found last file with same conditions, add the first file informations to listboxes. Enable Save XML button.
‘Save Results to XML’ Click
Disable this button. Define new XML document and load it. Check the all files from listboxes. Add to newElement  as file with file informations. Append the element to XML document. Don’t permission to whitespace in XML. Save XML as ‘data.xml’. Show the messageBox for succesfull process.
‘ListBox1 Item’ Selected
If there are too many files in list boxes, user can select one of them in listbox1. And then the other list boxes selected Item automaticaly with same index.
