using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    public class NewsFeed
    {
        public const string AUTHOR = "John";
        private readonly List<Post> posts;

        /// <summary>
        /// News feed.
        /// This code defines a constructor for a class called "NewsFeed". In the constructor, a new 
        /// List of "Post" objects is created and assigned to the "posts" variable. Then, two instances
        /// of "Post" subclasses, "MessagePost" and "PhotoPost", are created and added to the "posts" 
        /// list using the "AddMessagePost" and "AddPhotoPost" methods respectively.
        /// 
        /// The "MessagePost" instance is created with the constant string "AUTHOR" as the author name 
        /// and the message "I am confused" as the post's text content. The "PhotoPost" instance is 
        /// created with the same author name and a file name "Image1.png" and a caption "image 1 caption".
        /// </summary>
        public NewsFeed()
        {
            posts = new List<Post>();
            MessagePost post = new MessagePost(AUTHOR, "I am confused");
            AddMessagePost(post);

            PhotoPost photoPost = new PhotoPost(AUTHOR, "Image1.png", "image 1 caption");
            AddPhotoPost(photoPost);

        }

        /// <summary>
        /// Add Message Post.
        /// Defines a method that adds a message post to a list of posts. The method takes a single 
        /// argument, which is a message post.
        /// When the method is called and passed a message post, it adds that post to a list of posts 
        /// stored in the same class.
        /// </summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        /// <summary>
        /// Add Photo Post.
        /// This defines a method that adds a photo post to a list of posts. The method takes a single 
        /// argument, which is a photo post.
        /// When the method is called and passed a photo post, it adds that post to a list of posts stored 
        /// in the same class.
        /// </summary>
        /// <param name="photo"></param>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        /// <summary>
        /// Get posts.
        /// This section of code defines a method named "GetPosts" that returns a list of "Post" objects.
        ///
        /// Inside the method, the list of "Post" objects called "posts" is returned.This means that when
        /// this method is called, it will return the entire list of posts that are stored in the class.
        /// </summary>
        /// <returns></returns>
        public List<Post> GetPosts()
        {
            return posts;
        }

        /// <summary>
        /// Remove Post.
        /// This takes in a single parameter of type "Post".
        ///
        /// Inside the method, the "post" object passed in as a parameter is removed from a list of "Post" 
        /// objects called "posts" using the "Remove" method of the "List" class.
        /// </summary>
        /// <param name="post"></param>
        public void RemovePost(Post post)
        {
            posts.Remove(post);
        }

        /// <summary>
        /// This code defines a method called "AddCommentToPost" that takes in two parameters: an 
        /// integer "postId" and a string "commentText".
        ///
        /// Inside the method, there is an if statement that checks if the "postId" parameter is within
        /// the range of valid post IDs.If the "postId" parameter is valid, the corresponding post object
        /// is retrieved from the "posts" list using the index "postId-1". This is because post IDs start
        /// at 1 while the index in the list starts at 0.
        ///
        /// Once the post object is retrieved, the "AddComment" method of the "Post" class is called with
        /// the "commentText" parameter to add a new comment to the post.
        ///
        /// If the "postId" parameter is invalid, the method prints a message to the console indicating 
        /// that the post ID is invalid.
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentText"></param>
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

        /// <summary>
        /// Like and unlike Post.
        /// This code takes in a single parameter of type "int" called "index".
        ///
        /// Inside the method, there is an if statement that checks if the "index" parameter 
        /// is within the range of valid indices for the "posts" list.If the "index" parameter
        /// is not within the valid range, the method prints an error message to the console 
        /// and returns from the method.
        ///
        /// If the "index" parameter is within the valid range, the "Like" method of the 
        /// "Post" class is called on the post at the given index to increment its like count.
        /// The method then prints a message to the console indicating which post was liked.
        /// 
        /// Unlike works the same way.
        /// </summary>
        /// <param name="index"></param>
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


        /// <summary>
        /// Sort by Author
        /// This defines a method called "GetPostsByAuthor" that takes in a single parameter of type "string" called "author".
        ///
        /// Inside the method, a new list of "Post" objects called "filteredPosts" is created.Then, the method loops through 
        /// all the posts in the "posts" list using a foreach loop.
        ///
        /// For each post in the "posts" list, the method checks if the post's username (presumably the author of the post)
        /// matches the "author" parameter passed to the method. If the username matches the author, the post is added to the
        /// "filteredPosts" list using the "Add" method of the "List" class.
        ///
        ///Finally, the method returns the "filteredPosts" list, which contains all the posts from the "posts" list that were
        ///authored by the specified author.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Display
        ///  this method allows external code to display all the posts in the "posts" 
        ///  list with their details. The method loops through all the posts and prints
        ///  each post's details, one at a time.
        /// </summary>
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


        /// <summary>
        /// Filterd Display
        /// this method allows external code to display a filtered list of posts with their details. 
        /// The method checks if the filtered list is empty and, if not, it loops through the filtered
        /// list and prints each post's details, one at a time.
        /// 
        /// Inside the method, the method first prints a message to the console indicating that it will 
        /// display the filtered posts.
        ///
        /// Then, the method checks if the "posts" list passed as an argument is empty.If the list is 
        /// empty, the method prints a message to the console indicating that there are no posts to display.
        ///
        /// If the "posts" list is not empty, the method loops through all the posts in the "posts" 
        /// list using a foreach loop.For each post in the "posts" list, the method prints a message 
        /// to the console indicating the post number and the post itself.
        /// </summary>
        /// <param name="posts"></param>
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