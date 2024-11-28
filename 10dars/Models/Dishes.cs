namespace _10dars.Models;

public class Dishes
{
    //Id, Name, Price, Description, RestaurantId
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public Guid RestaurantId { get; set; }
}
