using _9dars.Models;
using _9dars.Servises;

namespace _9dars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static void StartFrontEndPost()
        {
            var postservic = new PostServis();

            while (true)
            {
                Console.WriteLine("0. Stop");
                Console.WriteLine("1. Add post");
                Console.WriteLine("2. Update post");
                Console.WriteLine("3. Delete post");
                Console.WriteLine("4. Get all post");
                Console.WriteLine("5. Get by post id");
                Console.WriteLine("6. Get most viewed post");
                Console.WriteLine("7. Get most liked post");
                Console.WriteLine("8. Get most commented post");
                Console.WriteLine("9. Get posts by comment");
                Console.WriteLine("10. Add Like");
                Console.WriteLine("11. Add comment to post");
                Console.WriteLine("12. Add viewer name");
                Console.Write("Select option: ");
                var option = Console.ReadLine();
                if (option == "0")
                {
                    break;
                }
                else if (option == "1")
                {
                    var post = new Post();
                    Console.Write("Enter owner name: ");
                    post.OwnerName = Console.ReadLine();
                    Console.Write("Enter post type: ");
                    post.Type = Console.ReadLine();
                    Console.Write("Enter post description: ");
                    post.Description = Console.ReadLine();
                    post.PostedTime = DateTime.Now;
                    post.QuantityLikes = 0;
                    post.Comments = new List<string>();
                    post.ViewerNames = new List<string>();
                    var result = postservic.AddNewPost(post);
                    if (result is true)
                    {
                        Console.WriteLine("Qo'shildi !");
                    }
                    else
                    {
                        Console.WriteLine("Xatolik !");
                    }
                }
                else if (option == "2")
                {
                    var post = new Post();
                    Console.Write("Enter the id of the post to update: ");
                    post.id = Guid.Parse(Console.ReadLine());
                    Console.Write("Enter updated owner name: ");
                    post.OwnerName = Console.ReadLine();
                    Console.Write("Enter updated new post type: ");
                    post.Type = Console.ReadLine();
                    Console.Write("Enter updated post description: ");
                    post.Description = Console.ReadLine();
                    post.PostedTime = DateTime.Now;
                    var result = postservic.UpdatePost(post);
                    if (result is true)
                    {
                        Console.WriteLine("Updated !");
                    }
                    else
                    {
                        Console.WriteLine("Error !");
                    }
                }
                else if (option == "3")
                {
                    Console.Write("Enter deleted post id: ");
                    var id = Guid.Parse(Console.ReadLine());
                    var result = postservic.DeletePost(id);
                    if (result is true)
                    {
                        Console.WriteLine("O'chirildi !");
                    }
                    else
                    {
                        Console.WriteLine("Xatolik !");
                    }
                }
                else if (option == "4")
                {
                    var posts = postservic.GetAllPosts();
                    foreach(var post in posts)
                    {
                        postservic.DisplayInfo(post);
                    }
                }
                else if (option == "5")
                {
                    Console.Write("Post id: ");
                    var id = Guid.Parse(Console.ReadLine());
                    var post = postservic.GetByPostId(id);
                    postservic.DisplayInfo(post);
                }
                else if (option == "6")
                {
                    var post = postservic.GetMostViewedPost();
                    postservic.DisplayInfo(post);
                }
                else if (option == "7")
                {
                    var post = postservic.GetMostLikedPost();
                    postservic.DisplayInfo(post);
                }
                else if (option == "8")
                {
                    var post = postservic.GetMostCommentedPost();
                    postservic.DisplayInfo(post);
                }
                else if (option == "9")
                {
                    Console.Write("Enter comment: ");
                    var comment = Console.ReadLine();
                    var posts = postservic.GetPostsByComment(comment);
                    foreach (var post in posts)
                    {
                        postservic.DisplayInfo(post);
                    }
                }
                else if (option == "10")
                {
                    Console.Write("Post id: ");
                    var id = Guid.Parse(Console.ReadLine());
                    var result = postservic.AddLike(id);
                    if (result is true)
                    {
                        Console.WriteLine("Liked");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                else if (option == "11")
                {
                    Console.Write("Post id: ");
                    var id = Guid.Parse(Console.ReadLine());
                    Console.Write("Enter comment: ");
                    var comment = Console.ReadLine();
                    var result = postservic.AddCommentToPost(id, comment);
                    if (result is true)
                    {
                        Console.WriteLine("Qo'wldi !");
                    }
                    else
                    {
                        Console.WriteLine("Xato !");
                    }
                }
                else if (option == "12")
                {
                    Console.Write("Enter id: ");
                    var id = Guid.Parse(Console.ReadLine());
                    Console.Write("Enter viewer name: ");
                    var name = Console.ReadLine();
                    var result = postservic.AddViewerName(id, name);
                    if (result is true)
                    {
                        Console.WriteLine("Qo'wldi !");
                    }
                    else
                    {
                        Console.WriteLine("Xato !");
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}