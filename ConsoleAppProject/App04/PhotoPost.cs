using System;
using System.Collections.Generic;


namespace ConsoleAppProject.App04
{
    /// <summary>
    /// A photo post on a social network.
    /// </summary>
    public class PhotoPost : Post
    {
        public string Filename { get; }
        public string Caption { get; }

        /// <summary>
        /// Constructor for photo post class.
        /// </summary>
        /// <param name="author">The user creating the post.</param>
        /// <param name="filename">The filename of the photo.</param>
        /// <param name="caption">The caption for the photo.</param>
        public PhotoPost(string author, string filename, string caption) : base(author)
        {
            Filename = filename;
            Caption = caption;
        }

        /// <summary>
        /// Displays the details of this photo post.
        /// </summary>
        public override void Display()
        {
            Console.WriteLine($"\n    Photo Filename: {Filename}");
            Console.WriteLine($"    Caption: {Caption}\n");
            base.Display();
        }
    }
}
