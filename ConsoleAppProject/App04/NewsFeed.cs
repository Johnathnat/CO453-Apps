using System;
using System.Collections.Generic;


namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///</author> 
    public class NewsFeed
    {
        public const string AUTHOR = "John";
        private readonly List<Post> posts;

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();

            MessagePost post = new MessagePost(AUTHOR, "I am confused");
            AddMessagePost(post);

            PhotoPost photoPost = new PhotoPost(AUTHOR, "Image1.png", "Image one caption");
            AddPhotoPost(photoPost);
        }


        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        ///<summary>
        /// Add a comment to the post with the specified ID.
        ///</summary>
        public void AddComment(int postId)
        {
            Console.WriteLine($"Enter a comment for post ID {postId}:");
            string comment = Console.ReadLine();

            Post post = GetPostById(postId);
            if (post == null)
            {
                Console.WriteLine($"Post with ID {postId} not found.");
            }
            else if (post is not ICommentable)
            {
                Console.WriteLine("This post cannot have comments.");
            }
            else
            {
                ((ICommentable)post).AddComment(comment);
                Console.WriteLine("Comment added successfully.");
            }
        }

        ///<summary>
        /// Like the post with the specified ID.
        ///</summary>
        public void LikePost(int postId)
        {
            Post post = GetPostById(postId);
            if (post == null)
            {
                Console.WriteLine($"Post with ID {postId} not found.");
            }
            else
            {
                post.Like();
                Console.WriteLine("Post liked successfully.");
            }
        }

        ///<summary>
        /// Unlike the post with the specified ID.
        ///</summary>
        public void UnlikePost(int postId, string username)
        {
            foreach (Post post in posts)
            {
                if (post.PostId == postId)
                {
                    if (post is IPostWithLikes)
                    {
                        IPostWithLikes postWithLikes = (IPostWithLikes)post;
                        postWithLikes.RemoveLike(username);
                        Console.WriteLine($"Post {postId} unliked by {username}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Post {postId} cannot be liked");
                    }
                    return;
                }
            }
            Console.WriteLine($"Error: Post {postId} not found");
        }

        public void RemovePost(Post post)
        {
            if (posts.Contains(post))
            {
                posts.Remove(post);
                Console.WriteLine("Post removed successfully!");
            }
            else
            {
                Console.WriteLine("Error: post not found.");
            }
        }

        ///<summary>
        /// Show all posts in the news feed.
        ///</summary>
        public void Display()
        {
            Console.WriteLine("   John's News Feed");
            Console.WriteLine("-------------------------");

            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine(); // empty line between posts
            }
        }

        ///<summary>
        /// Show all posts in the news feed that were posted by a specific author.
        /// 
        /// @param author  The author whose posts to display.
        ///</summary>
        public void DisplayByAuthor(string author)
        {
            Console.WriteLine($"   John's News Feed - Posts by {author}");
            Console.WriteLine("--------------------------------------------");

            bool authorFound = false;

            foreach (Post post in posts)
            {
                if (post.Username == author)
                {
                    post.Display();
                    Console.WriteLine(); // empty line between posts
                    authorFound = true;
                }
            }

            if (!authorFound)
            {
                Console.WriteLine($"No posts found by {author}.");
            }
        }

    }
}
