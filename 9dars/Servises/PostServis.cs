using _9dars.Models;

namespace _9dars.Servises;

public class PostServis
{
    private List<Post> posts;
    public PostServis()
    {
        posts = new List<Post>();
    }

    public bool AddNewPost(Post post)
    {
        try
        {
            post.id = Guid.NewGuid();
            posts.Add(post);
            return true;
        }
        catch
        {
            return false;
        }
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
        var index = posts.IndexOf(postFromDB);
        posts[index] = updatingPost;

        return true;
    }

    public List<Post> GetAllPosts()
    {
        return posts;
    }

    public void DisplayInfo(Post post)
    {
        Console.WriteLine($"\nPost ID: {post.id}");
        Console.WriteLine($"Owner Name: {post.OwnerName}");
        Console.WriteLine($"Post Type: {post.Type}");
        Console.WriteLine($"Post Description: {post.Description}");
        Console.WriteLine($"Posted Time: {post.PostedTime}");
        Console.WriteLine($"Quantity of Likes: {post.QuantityLikes}");

        Console.WriteLine("Comments:");
        if (post.Comments != null && post.Comments.Count > 0)
        {
            foreach (var comment in post.Comments)
            {
                Console.WriteLine($"  - {comment}");
            }
        }
        else
        {
            Console.WriteLine("  No comments yet.");
        }

        Console.WriteLine("\nViewer Names:");
        if (post.ViewerNames != null && post.ViewerNames.Count > 0)
        {
            foreach (var name in post.ViewerNames)
            {
                Console.WriteLine($"  - {name}");
            }
        }
        else
        {
            Console.WriteLine("  No viewers yet.");
        }
    }

    public Post GetMostViewedPost()
    {
        var mostViewedPost = new Post();
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
        Post mostLikedPost = new Post();
        var mostLike = 0;
        foreach (var post in posts)
        {
            if (post.QuantityLikes > mostLike)
            {
                mostLike = post.ViewerNames.Count;
                mostLikedPost = post;
            }
        }

        return mostLikedPost;
    }
    public Post GetMostCommentedPost()
    {
        Post mostCommentedPost = new Post();
        var mostComment = 0;
        foreach (var post in posts)
        {
            if (post.Comments.Count > mostComment)
            {
                mostComment = post.ViewerNames.Count;
                mostCommentedPost = post;
            }
        }

        return mostCommentedPost;
    }

    public List<Post> GetPostsByComment(string comment)
    {
        var ComnetdetPosts = new List<Post>();
        foreach (var post in posts)
        {
            var comments = post.Comments;
            if (comment.Contains(comment) is true)
            {
                ComnetdetPosts.Add(post);
            }
        }

        return ComnetdetPosts;
    }
    public bool AddLike(Guid id)
    {
        var postFromDB = GetByPostId(id);
        if (postFromDB is null)
        {
            return false;
        }
        postFromDB.QuantityLikes++;

        return true;
    }
    public bool AddCommentToPost(Guid id, string comment)
    {
        var postFromDB = GetByPostId(id);
        if (postFromDB is null)
        {
            return false;
        }
        postFromDB.Comments.Add(comment);

        return true;
    }
    public bool AddViewerName(Guid id, string name)
    {
        var postFromDB = GetByPostId(id);
        if (postFromDB is null)
        {
            return false;
        }
        postFromDB.ViewerNames.Add(name);

        return true;
    }
}
