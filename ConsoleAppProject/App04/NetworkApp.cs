using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    public class NetworkApp
    {
        private NewsFeed news = new NewsFeed();
        /// <summary>
        /// 
        /// </summary>
        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("  John's News Feed");
            string[] choices = new string[]
            {
                "Post Message","Post Image", ""+
                "Display All Posts","Quit"
            };
            bool wantToQuit = false;
            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);
                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: DisplayAll(); break;
                    case 4: wantToQuit = true; break;
                }
            } while (!wantToQuit);

        }

        private void DisplayAll()
        {
            news.Display();
        }

        private void PostImage()
        {
            Console.WriteLine("Enter the image file name:");
            string fileName = Console.ReadLine();

            Console.WriteLine("Enter a caption for the image:");
            string caption = Console.ReadLine();

            string author = "John"; // Replace with the actual author's name

            PhotoPost photoPost = new PhotoPost(author, fileName, caption);
            news.AddPhotoPost(photoPost);

            Console.WriteLine("Your image has been posted.");
        }

        private void PostMessage()
        {
            Console.WriteLine("Enter your message:");
            string newMessage = Console.ReadLine();
            string author = "John"; // Replace with the actual author's name

            MessagePost post = new MessagePost(author, newMessage);
            news.AddMessagePost(post);

            Console.WriteLine("Your message has been posted.");
        }
    }
}