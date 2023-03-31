using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    public class PhotoPost : Post
    {
        public String Filename { get; set; }
        public String Caption { get; set; }

        public PhotoPost(String author, String filename, String caption) : base(author)
        {
            this.Filename = filename;
            this.Caption = caption;
        }

        public override void Display()
        {
            Console.WriteLine($"    Filename: [{Filename}]");
            Console.WriteLine($"    Caption: {Caption}");
            base.Display();
        }

    }
}