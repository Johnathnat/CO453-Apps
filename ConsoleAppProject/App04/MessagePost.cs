using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
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