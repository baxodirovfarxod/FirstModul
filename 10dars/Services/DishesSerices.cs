using _10dars.Models;

namespace _10dars.Services;

public class DishesSerices
{
    private List<Dishes> dishes;
    public DishesSerices()
    {
        dishes = new List<Dishes>();
    }

    // Add
    public Dishes AddDishes(Dishes dish)
    {
        dish.Id = Guid.NewGuid();
        dishes.Add(dish);
        return dish;
    }
    // Get by id
    public Dishes GetById(Guid Id)
    {
        foreach (var dish in dishes)
        {
            if (dish.Id == Id)
            {
                return dish;
            }
        }

        return null;
    }
    // Update
    public bool UpdateDish(Dishes updatedDish)
    {
        var dishDB = GetById(updatedDish.Id);
        if (dishDB is null)
        {
            return false;
        }
        var index = dishes.IndexOf(dishDB);
        dishes[index] = updatedDish;

        return true;
    }
    // Delete
    public bool DeleteDish(Guid Id)
    {
        var dishDB = GetById(Id);
        if (dishDB is null)
        {
            return false;
        }
        dishes.Remove(dishDB);

        return true;
    }
    // Get all
    public List<Dishes> GetAll()
    {
        return dishes;
    }
    // connect
    public bool ConnectDishWithRestaurant(Guid restaurantID, Guid disheId)
    {
        var dishDb = GetById(disheId);
        if (dishDb is null)
        {
            return false;
        }
        var index = dishes.IndexOf(dishDb);
        dishes[index].RestaurantId = restaurantID;

        return true;
    }
    // SearchDishByName()
    public Dishes SearchDishByName(string name)
    {
        foreach (var dish in dishes)
        {
            if (dish.Name == name)
            {
                return dish;
            }
        }

        return null;
    }
    // AssignDishToAnotherRestaurant()
    public bool AssignDishToAnotherRestaurant(Guid dishId, Guid newRestaurantID)
    {
        var dishFromDb = GetById(dishId);
        if (dishFromDb is null)
        {
            return false;
        }
        var index = dishes.IndexOf(dishFromDb);
        dishes[index].RestaurantId = newRestaurantID;

        return true;
    }
}