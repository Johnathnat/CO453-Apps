using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This is an abstract class to represent a post in a social network application.
    /// 
    /// Display of the post is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.2
    ///</author> 
    public abstract class Post
    {
        private readonly int postID;
        private static int instances = 0;

        public string Username { get; }

        public DateTime Timestamp { get; }

        public int Likes { get; private set; }

        private readonly List<Comment> comments;

        ///<summary>
        /// Constructor for objects of class Post.
        ///</summary>
        ///<param name="author">The username of the author of this post.</param>
        public Post(string author)
        {
            Username = author;
            Timestamp = DateTime.Now;

            postID = ++instances;

            comments = new List<Comment>();
        }

        ///<summary>
        /// Add a comment to this post.
        /// 
        /// @param commentText  The text of the comment to be added.
        /// @param username     The username of the author of the comment.
        ///</summary>
        public void AddComment(string commentText, string username)
        {
            Comment comment = new Comment(commentText, username);
            comments.Add(comment);
        }

        ///<summary>
        /// Increase the number of likes for this post by 1.
        ///</summary>
        public void Like()
        {
            Likes++;
        }

        ///<summary>
        /// Decrease the number of likes for this post by 1.
        ///</summary>
        public void Unlike()
        {
            if (Likes > 0)
            {
                Likes--;
            }
        }

        ///<summary>
        /// Display the details of this post.
        /// 
        /// This will display the username of the author, the timestamp of the post,
        /// the number of likes, and the comments associated with the post.
        /// 
        /// This is an abstract method. Subclasses will need to provide their own implementation
        /// of the Display method.
        ///</summary>
        public abstract void Display();

        ///<summary>
        /// Return a string representation of this post.
        ///</summary>
        public override string ToString()
        {
            string output = $"ID: {postID}\n" +
                            $"Author: {Username}\n" +
                            $"Timestamp: {Timestamp}\n" +
                            $"Likes: {Likes}\n" +
                            $"Comments: {comments.Count}";

            return output;
        }
    }
}
