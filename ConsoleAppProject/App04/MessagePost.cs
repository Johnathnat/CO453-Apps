using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// The MessagePost class is a subclass of the Post class and represents a post that contains
    /// a message, which is a string of text. 
    /// It has a constructor that takes an author name and the message text as arguments, and it
    /// calls the base constructor to initialize the author name.
    /// It also has a Display method that overrides the base Display method to print the message
    /// text along with the other post details
    /// </summary>
    public class MessagePost : Post
    {
        public String Message { get; }

        public MessagePost(String author, String text) : base(author)
        {
            Message = text;
        }
       
        public override void Display()
        {
            Console.WriteLine($"    Message: {Message}");
            base.Display();
        }
    }
}