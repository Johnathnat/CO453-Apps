using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// This class represents a message post in the news feed.
    /// </summary>
    public class MessagePost : Post
    {
        // The message that will be posted
        public string Message { get; set; }

        /// <summary>
        /// Constructor for objects of class MessagePost.
        /// </summary>
        public MessagePost(string author, string message) : base(author)
        {
            Message = message;
        }

        /// <summary>
        /// Display the details of this message post.
        /// </summary>
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Message: " + Message);
        }
    }
}