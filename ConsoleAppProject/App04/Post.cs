
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
    public class Post
    {
        private int likes;


        private readonly List<String> comments;

        public String Username { get; } // username of the post's author

        public DateTime Timestamp { get; }

        public Post(string author)
        {
            this.Username = author;
            Timestamp = DateTime.Now;

            likes = 0;
            comments = new List<String>();
        }

        public void Like()
        {
            likes++;
        }

        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }

        public void AddComment(String text) // Add a comment to this post.
        {
            comments.Add(text);
        }

        public virtual void Display() // Display the details of this post.
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

        private String FormatElapsedTime(DateTime time) // Create a string describing a time point in the past in terms relative to current time, such as "30 seconds ago" or "7 minutes ago".
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