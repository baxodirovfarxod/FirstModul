﻿using _9dars.Models;

namespace _9dars.Servises;

public class PostServis
{
    private List<Post> posts;
    public PostServis()
    {
        var posts = new List<Post>();
    }

    public Post AddNewPost(Post post)
    {
        post.id = Guid.NewGuid();
        posts.Add(post);

        return post;
    }
    public Post GetByPostId(Guid id)
    {
        foreach (var post in posts)
        {
            if (post.id == id)
            {
                return post;
            }
        }

        return null;
    }

    public bool DeletePost(Guid id)
    {
        var postFromDB = GetByPostId(id);
        if (postFromDB is null)
        {
            return false;
        }
        posts.Remove(postFromDB);
        return true;
    }

    public bool UpdatePost(Post updatingPost)
    {
        var postFromDB = GetByPostId(updatingPost.id);
        if (postFromDB is null)
        {
            return false;
        }
        var index = posts.IndexOf(updatingPost);
        posts[index] = updatingPost;

        return true;
    }

    public List<Post> GetAllPosts()
    {
        return posts;
    }

    public Post GetMostViewedPost()
    {
        Post mostViewedPost = null;
        var mostView = 0;
        foreach (var post in posts)
        {
            if (post.ViewerNames.Count > mostView)
            {
                mostView = post.ViewerNames.Count;
                mostViewedPost = post;
            }
        }

        return mostViewedPost;
    }
    public Post GetMostLikedPost()
    {
        Post mostLikedPost = null;
        var mostView = 0;
        foreach (var post in posts)
        {
            if (post.ViewerNames.Count > mostView)
            {
                mostView = post.ViewerNames.Count;
                mostLikedPost = post;
            }
        }

        return mostLikedPost;
    }
}