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
                "Display All Posts","Add Comments","Remove Post","Quit"
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
                    case 4: AddComments(); break;
                    case 5: RemovePost(); break;
                    case 6: wantToQuit = true; break;
                }
            } while (!wantToQuit);

        }

        private void RemovePost()
        {
            List<Post> allPosts = news.GetPosts();

            if (allPosts.Count == 0)
            {
                Console.WriteLine("There are no posts to remove.");
                return;
            }

            Console.WriteLine("Select a post to remove:");
            for (int i = 0; i < allPosts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allPosts[i].ToString()}");
            }
            Console.WriteLine(allPosts.Count);
            if (int.TryParse(Console.ReadLine(), out int postIndex))
            {
                // use postIndex variable here
                // ...
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            news.RemovePost(allPosts[postIndex - 1]);

            Console.WriteLine("The post has been removed.");
        }

        private void AddComments()
        {
            Console.WriteLine("Enter the index of the post you want to comment on:");
            int postIndex = ConsoleHelper.InputInterger("Post index: ", 1, (news.GetPosts().Count) - 1);

            Console.WriteLine($"Enter your comment for post {postIndex + 1}:");
            string comment = Console.ReadLine();

            news.GetPosts()[postIndex].AddComment(comment);
            Console.WriteLine("Comment added successfully!");
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