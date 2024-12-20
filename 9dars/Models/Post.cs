﻿namespace _9dars.Models;

public class Post
{
    public Guid id { get; set; }
    public string OwnerName { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime PostedTime { get; set; }
    public int QuantityLikes { get; set; }
    public List<string> Comments { get; set; }
    public List<string> ViewerNames { get; set; } 
}
