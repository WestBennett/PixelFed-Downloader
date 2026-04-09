Since there doesn't YET exist the ability to download all of your media en masse from PixelFed, I wrote this basic program to let users download their content to their computers.

<img width="321" height="464" alt="image" src="https://github.com/user-attachments/assets/799730a8-296b-4758-b053-bda1227c8f6b" />


The interface itself is pretty simple, not too much to worry about. Here's the steps for usage:
1.  Choose your options on the screen
2.  Click the Download button and select your "pixelfed-statuses.json" file that you downloaded from the PixelFed instance, then choose your final output directory to place the files at.
3.  Wait for the results, which will be shown in the final MessageBox
4.  Check out the status TextBox in case you want to see ALL the details of exactly what the program did.

Here's a short explanation of the options - 

**"Make Separate Folders Per ID"** Checkbox lets you automatically create new folders per post ID:

<img width="487" height="566" alt="image" src="https://github.com/user-attachments/assets/7c137703-fd02-4640-bc89-af2007c9f81f" />

Default behavior if unchecked is to throw all the files into the output directory chosen by the user.

**File Handling Options:**
1.  Overwrite Existing Files - does exactly what it says it does. If it finds a file in the final output location, it will delete it before downloading the replacement.
2.  Rename Downloaded Files - IF the file is found to exist already at the specified final destination, a loop is run that adds a suffix of "_1" (or "_2", etc) and keeps incrementing the suffix number until it finds a file that does NOT yet exist. This filename will be the final destination of the file.

...and that's it! Just a quick program I whipped up because it bothered me that there seemed to be no easy and quick way within PixelFed to just download all of your media in case you want it!

**Released under the Creative Commons Attribution Share Alike 4.0 International License.**

_I just wish they'd build that functionality into PixelFed natively, but I'm primarily a Desktop applications programmer, I'm not very good with web code!!!_
