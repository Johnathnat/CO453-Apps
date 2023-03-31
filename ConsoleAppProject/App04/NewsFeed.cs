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

        public List<Post> GetPosts()
        {
            return posts;
        }

        public void RemovePost(Post post)
        {
            posts.Remove(post);
        }

        public void AddCommentToPost(int postId, string commentText)
        {

            if (postId >= 0 && postId < posts.Count)
            {
                Post post = posts[postId - 1];
                post.AddComment(commentText);
            }
            else
            {
                Console.WriteLine($"Invalid post ID: {postId}");
            }
        }

        public void LikePost(int index)
        {
            if (index < 0 || index >= posts.Count)
            {
                Console.WriteLine("Invalid post index.");
                return;
            }

            posts[index].Like();
            Console.WriteLine($"Post {index+1} liked.");
        }

        public void UnlikePost(int index)
        {
            if (index < 0 || index >= posts.Count)
            {
                Console.WriteLine("Invalid post index.");
                return;
            }

            posts[index].Unlike();
            Console.WriteLine($"Post {index+1} unliked.");
        }

        public List<Post> GetPostsByAuthor(string author)
        {
            List<Post> filteredPosts = new List<Post>();

            foreach (var post in posts)
            {
                if (post.Username == author)
                {
                    filteredPosts.Add(post);
                }
            }

            return filteredPosts;
        }

        public void Display()
        {
            Console.WriteLine("All posts:\n");

            for (int i = 0; i < posts.Count; i++)
            {
                Console.WriteLine($"Post No {i + 1}. ");
                posts[i].Display();
                Console.WriteLine();
            }
        }

        public void FilterdDisplay(List<Post> posts)
        {
            Console.WriteLine("\nFiltered Posts:");

            if (posts.Count == 0)
            {
                Console.WriteLine("No posts to display.");
            }
            else
            {
                int i = 1;
                foreach (Post post in posts)
                {
                    Console.WriteLine($"[{i}] {post}");
                    i++;
                }
            }
        }

    }
}