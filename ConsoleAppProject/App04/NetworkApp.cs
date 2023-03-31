using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    public class NetworkApp
    {
        private NewsFeed news = new NewsFeed();

        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("    John's Social Network    ");

            string[] choices = new string[]
            {
                "Post Message", "Post Image", "Remove Post", "Display All Posts",
                "Display Posts by Author", "Display Posts by Date", "Add Comment", "Like Post",
                "Unlike Post", "Quit"
            };

            bool wantToQuit = false;
            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);

                switch (choice)
                {
                    case 1:
                        PostMessage();
                        break;

                    case 2:
                        PostImage();
                        break;

                    case 3:
                        RemovePost();
                        break;

                    case 4:
                        DisplayAll();
                        break;

                    case 5:
                        DisplayByAuthor();
                        break;

                    case 6:
                        DisplayByDate();
                        break;

                    case 7:
                        AddComment();
                        break;

                    case 8:
                        LikePost();
                        break;

                    case 9:
                        UnlikePost();
                        break;

                    case 10:
                        wantToQuit = true;
                        break;
                }

            } while (!wantToQuit);
        }
        //post a message
        private void PostMessage()
        {
            ConsoleHelper.OutputTitle("Posting a Message");

            Console.Write("Enter your username > ");
            string author = Console.ReadLine();

            Console.Write("Enter your message > ");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(author, message);
            news.AddMessagePost(post);

            ConsoleHelper.OutputTitle("Message Posted:");
            post.Display();
        }
        //post a image
        private void PostImage()
        {
            ConsoleHelper.OutputTitle("Posting an Image");

            Console.Write("Enter your username > ");
            string author = Console.ReadLine();

            Console.Write("Enter the filename of your image > ");
            string filename = Console.ReadLine();

            Console.Write("Enter a caption for your image > ");
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(author, filename, caption);
            news.AddPhotoPost(post);

            ConsoleHelper.OutputTitle("Image Posted:");
            post.Display();
        }
        //remove a post
        private void RemovePost()
        {
            ConsoleHelper.OutputTitle("Removing a Post");

            Console.Write("Enter the ID of the post to remove > ");
            int id = int.Parse(Console.ReadLine());

            if (news.RemovePost(id))
            {
                ConsoleHelper.OutputTitle("Post Removed Successfully!");
            }
            else
            {
                ConsoleHelper.OutputTitle($"Post with ID {id} was not found!");
            }
        }
        //display all
        private void DisplayAll()
        {
            ConsoleHelper.OutputTitle("Displaying All Posts");

            news.Display();
        }

        //display by date
        private void DisplayByDate()
        {
            ConsoleHelper.OutputTitle("Display Posts by Date");

            Console.Write("Enter the start date (yyyy-mm-dd) > ");
            DateTime start = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter the end date (yyyy-mm-dd) > ");
            DateTime end = DateTime.Parse(Console.ReadLine());

            List<Post> posts = news.GetPostsByDate(start, end);

            if (posts.Count == 0)
            {
                Console.WriteLine("No posts found within the specified date range.");
            }
            else
            {
                ConsoleHelper.OutputTitle($"Displaying Posts from {start:yyyy-MM-dd} to {end:yyyy-MM-dd}");

                foreach (Post post in posts)
                {
                    post.Display();
                    Console.WriteLine(); // empty line between posts
                }
            }
        }
        //Comments
        private void AddComment()
        {
            ConsoleHelper.OutputTitle("Adding a Comment");

            Console.Write("Enter the ID of the post > ");
            int postId = int.Parse(Console.ReadLine());

            Post post = news.FindPostById(postId);

            if (post != null)
            {
                Console.Write($"Enter your name > ");
                string commenter = Console.ReadLine();

                Console.Write($"Enter your comment > ");
                string message = Console.ReadLine();

                Comment comment = new Comment(commenter, message);
                post.AddComment(comment);

                ConsoleHelper.OutputTitle("Comment Added:");
                post.Display();
            }
            else
            {
                Console.WriteLine($"Post with ID {postId} not found.");
            }
        }

        //Like a post
        private void LikePost()
        {
            ConsoleHelper.OutputTitle("Like a Post");

            Console.Write("Enter the ID of the post you want to like > ");
            int id = ConsoleHelper.ParseInt();

            Post post = news.FindPost(id);

            if (post == null)
            {
                Console.WriteLine($"Post with ID {id} not found");
            }
            else
            {
                post.Like();
                Console.WriteLine($"Post {id} liked");
            }
        }

        //unlike a post
        private void UnlikePost()
        {
            ConsoleHelper.OutputTitle("Unliking a Post");
            int id = (int)ConsoleHelper.InputNumber("Enter the post ID: ");

            Post post = news.FindPostById(id);

            if (post == null)
            {
                Console.WriteLine($"Error: No post found with ID = {id}");
            }
            else if (post is MessagePost || post is PhotoPost)
            {
                post.Unlike();
                Console.WriteLine($"Post {id} unliked");
            }
            else
            {
                Console.WriteLine($"Error: Post {id} is not a likable post");
            }
        }


    }
}
