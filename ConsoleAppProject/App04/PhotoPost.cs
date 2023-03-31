using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// The PhotoPost class is a derived class of the Post class and represents a post that
    /// includes a photo with a filename and a caption. 
    /// It has three properties: Author (inherited from Post), Filename, and Caption.
    /// </summary>
    public class PhotoPost : Post
    {
        public String Filename { get; set; }
        public String Caption { get; set; }

        /// <summary>
        /// The PhotoPost constructor takes three parameters: author, filename, and caption. 
        /// The author parameter is used to initialize the Author property inherited from 
        /// the Post class, and the filename and caption parameters are used to initialize
        /// the Filename and Caption properties of the PhotoPost class, respectively.
        /// </summary>
        public PhotoPost(String author, String filename, String caption) : base(author)
        {
            this.Filename = filename;
            this.Caption = caption;
        }

        /// <summary>
        /// The Display() method is overridden from the Post class and displays the Filename
        /// and Caption properties in addition to calling the Display() method of the base 
        /// Post class to display the common properties of all posts such as Author, 
        /// Timestamp, Likes, and Comments.
        /// </summary>
        public override void Display()
        {
            Console.WriteLine($"    Filename: [{Filename}]");
            Console.WriteLine($"    Caption: {Caption}");
            base.Display();
        }

    }
}