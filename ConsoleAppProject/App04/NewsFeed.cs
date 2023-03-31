using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    public class NewsFeed
    {
        public const string AUTHOR = "John";
        private readonly List<Post> posts;

        public NewsFeed()
        {
            posts = new List<Post>();
            MessagePost post = new MessagePost(AUTHOR, "I am confused");
            AddMessagePost(post);

            PhotoPost photoPost = new PhotoPost(AUTHOR, "Image1.png", "image 1 caption");
            AddPhotoPost(photoPost);

        }

        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        public void Display()
        {
            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine();
            }
        }
    }
}