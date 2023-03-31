
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
    public class Post
    {
        //Number of likes
        private int likes;
        //List of comments
        private readonly List<String> comments;
        
        // username of the post's author
        public String Username { get; } 
        //Time and date of post
        public DateTime Timestamp { get; }

        //The metadata of the post
        public Post(string author)
        {
            this.Username = author;
            Timestamp = DateTime.Now;

            likes = 0;
            comments = new List<String>();
        }

        //like addition
        public void Like()
        {
            likes++;
        }
        //like subtraction. Wont go below 0
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }


        // Add a comment to this post.
        public void AddComment(String text) 
        {
            comments.Add(text);
        }


        // Display the details of this post in a userfriednly way.
        public virtual void Display() 
        {
            Console.WriteLine();
            Console.WriteLine($"    Author: {Username}");
            Console.WriteLine($"    Time Elapsed: {FormatElapsedTime(Timestamp)}");
            Console.WriteLine();

            if (likes == 0)
            {
                Console.WriteLine("    No likes.");
            }
            else if (likes == 1)
            {
                Console.WriteLine("    1 person likes this.");
            }
            else
            {
                Console.WriteLine($"    {likes} people like this.");
            }

            if (comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
            }
            else
            {
                Console.WriteLine($"    {comments.Count} comment(s). Click here to view.");
            }
        }

        // Create a string describing a time point in the past in terms relative to current time, such as "30 seconds ago" or "7 minutes ago".
        private String FormatElapsedTime(DateTime time) 
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }
    }
}