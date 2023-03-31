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
        /// Display Menu
        /// This code defines a method called "DisplayMenu" that displays a console-based menu for interacting with a news feed.
        /// 
        /// The method first calls a helper method called "OutputHeading" from a "ConsoleHelper" class to display a heading for 
        /// the news feed.
        /// 
        /// Then, the method creates an array of strings called "choices" that contains the options available in the menu.
        /// These options include adding a message post, adding an image post, displaying all posts, adding comments to a post, 
        /// removing a post, liking a post, unliking a post, displaying posts by author, and quitting the program.
        /// 
        /// The method then enters a do-while loop that continues to display the menu and accept input from the user until the 
        /// user chooses to quit.The user's input is obtained by calling a helper method called "SelectChoice" from the 
        /// "ConsoleHelper" class, which presents the user with the available choices and returns the index of the user's choice.
        /// 
        /// The method then uses a switch statement to determine which action to take based on the user's choice. Each case 
        /// statement corresponds to one of the menu options and calls a corresponding method to perform the desired action.
        /// 
        /// The loop continues to display the menu and accept input until the user chooses to quit, at which point the loop 
        /// terminates, and the method ends.
        /// </summary>
        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("  John's News Feed");
            string[] choices = new string[]
            {
                "Post Message","Post Image", ""+
                "Display All Posts","Add Comments","Remove Post","Like Post","Unlike Post","Display posts by author","Quit"
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
                    case 6: LikePost(); break;
                    case 7: UnlikePost(); break;
                    case 8: SortByAuthor(); break;
                    case 9: wantToQuit = true; break;
                }
            } while (!wantToQuit);

        }


        /// <summary>
        /// Sort By Author
        /// This is a private helper method that is called when the user selects the option
        /// to display posts by author in the news feed menu. It prompts the user to enter the 
        /// username of the author whose posts they want to view, then retrieves all posts from 
        /// the news feed that were authored by that user by calling the GetPostsByAuthor method.
        /// If there are no posts by that author, it outputs a message indicating that no posts were
        /// found. If there are posts by the author, it outputs a message indicating how many posts 
        /// were found, and then calls the FilterdDisplay method to display the posts in a filtered
        /// manner.
        /// </summary>
        private void SortByAuthor()
        {
            Console.Write("Enter the author's username: ");
            string author = Console.ReadLine();

            List<Post> filteredPosts = news.GetPostsByAuthor(author);

            if (filteredPosts.Count == 0)
            {
                Console.WriteLine($"No posts found by author {author}.");
            }
            else
            {
                Console.WriteLine($"Showing {filteredPosts.Count} post(s) by {author}:");
                news.FilterdDisplay(filteredPosts);
            }
        }


        /// <summary>
        /// These two methods allow the user to like or unlike a post by selecting its index 
        /// from the list of all posts in the news feed.
        /// 
        /// The LikePost() method prompts the user to enter the index of the post they want to
        /// like and calls the LikePost() method of the news object with the provided index.
        /// It then outputs a success message to the console.
        /// 
        /// The UnlikePost() method is similar, but it calls the UnlikePost() method of the 
        /// news object with the provided index to remove the like from the post.It also outputs a success message to the console.
        /// </summary>
        public void LikePost()
        {
            Console.WriteLine("Enter the index of the post you want to like:");
            int postIndex = ConsoleHelper.InputInterger("Post index: ", 1, news.GetPosts().Count) - 1;

            news.LikePost(postIndex);
            Console.WriteLine("Post liked successfully!");
        }

        public void UnlikePost()
        {
            Console.WriteLine("Enter the index of the post you want to unlike:");
            int postIndex = ConsoleHelper.InputInterger("Post index: ", 1, news.GetPosts().Count) - 1;

            news.UnlikePost(postIndex);
            Console.WriteLine("Post unliked successfully!");
        }


        /// <summary>
        /// Remove post
        /// The method first gets a list of all posts from the news feed using the GetPosts method.
        /// If there are no posts, the method prints a message and returns. Otherwise, the method 
        /// displays a numbered list of all posts using a for loop.
        /// 
        /// Then, the method prompts the user to select a post to remove by entering its corresponding
        /// number.It uses the InputInterger method from a ConsoleHelper class to validate and parse 
        /// the user's input as an integer between 1 and the number of posts in the list. It subtracts
        /// 1 from the input to get the index of the selected post in the list.
        /// 
        /// Finally, the method calls the RemovePost method of the news feed, passing in the selected
        /// post to remove it from the list, and prints a confirmation message.
        /// </summary>
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



        /// <summary>
        /// The AddComments method is responsible for adding a comment to a post. 
        /// It first prompts the user to enter the index of the post they want to 
        /// comment on, and then prompts the user to enter the comment text. 
        /// It then calls the AddComment method of the Post class, passing in the 
        /// comment text as an argument. 
        /// Finally, it prints a message indicating that the comment was added successfully.
        /// </summary>
        private void AddComments()
        {

            Console.WriteLine("Enter the index of the post you want to comment on:");
            int postIndex = ConsoleHelper.InputInterger("Post index: ", 1, news.GetPosts().Count) - 1;

            Console.WriteLine($"Enter your comment for post {postIndex + 1}:");
            string comment = Console.ReadLine();

            news.GetPosts()[postIndex].AddComment(comment);
            Console.WriteLine("Comment added successfully!");
        }


        /// <summary>
        /// This simply calls the Display method of the NewsFeed class, 
        /// which outputs all the posts in the news feed to the console.
        /// </summary>
        private void DisplayAll()
        {
            news.Display();
        }


        /// <summary>
        /// Post Image
        /// When the method is called, it prompts the user to enter the file name of the image, 
        /// a caption for the image, and the author's name. It then creates a new PhotoPost 
        /// object with the provided information and adds it to the NewsFeed instance.
        /// Finally, it outputs a message confirming that the image has been posted.
        /// </summary>
        private void PostImage()
        {
            Console.WriteLine("Enter the image file name:");
            string fileName = Console.ReadLine();

            Console.WriteLine("Enter a caption for the image:");
            string caption = Console.ReadLine();

            Console.WriteLine("Enter Authers Name:");
            string author = Console.ReadLine();
            PhotoPost photoPost = new PhotoPost(author, fileName, caption);
            news.AddPhotoPost(photoPost);

            Console.WriteLine("Your image has been posted.");
        }


        /// <summary>
        /// The PostMessage() method prompts the user to input a message and the author's name.
        /// It then creates a new MessagePost object with the provided message and author, and
        /// adds the post to the NewsFeed object using the AddMessagePost() method.
        /// Finally, it displays a message to the user confirming that the message has been posted.
        /// </summary>
        private void PostMessage()
        {
            Console.WriteLine("Enter your message:");
            string newMessage = Console.ReadLine();


            Console.WriteLine("Enter Authers Name:");
            string author = Console.ReadLine(); 

            MessagePost post = new MessagePost(author, newMessage);
            news.AddMessagePost(post);

            Console.WriteLine("Your message has been posted.");
        }
    }
}