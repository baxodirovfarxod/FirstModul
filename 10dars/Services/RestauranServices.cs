using _10dars.Models;

namespace _10dars.Services;

public class RestauranServices
{
    private List<Restaurant> restaurants;

    public RestauranServices()
    {
        restaurants = new List<Restaurant>();
    }
    // Add 
    public Restaurant AddRestaurant(Restaurant restaurant)
    {
        restaurant.Id = Guid.NewGuid();
        restaurants.Add(restaurant);

        return restaurant;
    }
    // Get by Id
    public Restaurant GetById(Guid Id)
    {
        foreach (var restaurant in restaurants)
        {
            if (restaurant.Id == Id)
            {
                return restaurant;
            }
        }

        return null;
    }
    // Update
    public bool UpdateRestaurant(Restaurant updatedRestaurant)
    {
        var restaurantDB = GetById(updatedRestaurant.Id);
        if (restaurantDB is null)
        {
            return false;
        }
        var index = restaurants.IndexOf(restaurantDB);
        restaurants[index] = updatedRestaurant;

        return true;
    }
    // Delete
    public bool DeleteRestaurant(Guid Id)
    {
        var restaurantDB = GetById(Id);
        if (restaurantDB is null)
        {
            return false;
        }
        restaurants.Remove(restaurantDB);

        return true;
    }
    // Read all
    public List<Restaurant> GetAll()
    {
        return restaurants;
    }
    // GetTopRatedRestaurant()
    public Restaurant GetTopRatedRestaurant()
    {
        var topRateRestauran = new Restaurant();
        foreach (var restaurant in restaurants)
        {
            if (restaurant.Rating > topRateRestauran.Rating)
            {
                topRateRestauran = restaurant;
            }
        }

        return topRateRestauran;
    }
    // GetRestaurantsByLocation()
    public List<Restaurant> GetRestaurantsByLocation(string location)
    {
        var restaurantsByLocation = new List<Restaurant>();
        foreach (var restaurant in restaurants)
        {
            if (restaurant.Location == location)
            {
                restaurantsByLocation.Add(restaurant);
            }
        }

        return restaurantsByLocation;
    }
    public bool ConnectRestaurantToDishes(Guid restaurantID, Dishes dishes)
    {
        var restaurantDB = GetById(restaurantID);
        if (restaurantDB is null)
        {
            return false;
        }
        var index = restaurants.IndexOf(restaurantDB);
        restaurants[index].Dishes.Add(dishes);

        return true;
    }
    // GetMostExpensiveDishByRestaurant()
    public Dishes GetMostExpensiveDishByRestaurant(Restaurant restaurant)
    {
        var dish = new Dishes();
        foreach (var dishes in restaurant.Dishes)
        {
            if (dishes.Price > dish.Price)
            {
                dish = dishes;
            }
        }

        return dish;
    }
    // GetAllDishesUnderPrice()
    public List<Dishes> GetAllDishesUnderPrice(double price)
    {
        var dishesList = new List<Dishes>();
        foreach (var restaurant in restaurants)
        {
            foreach (var dish in restaurant.Dishes)
            {
                if (dish.Price <= price)
                {
                    dishesList.Add(dish);
                }
            }
        }

        return dishesList;
    }
    // GetRestaurantWithMostDishes()
    public Restaurant GetRestaurantWithMostDishes()
    {
        var restaurantWithMostDishes = new Restaurant();
        foreach (var restaurant in restaurants)
        {
            if (restaurant.Dishes.Count > restaurantWithMostDishes.Dishes.Count)
            {
                restaurantWithMostDishes = restaurant;
            }
        }

        return restaurantWithMostDishes;
    }
    // AssignDishToAnotherRestaurant()
    public bool AssignDishToAnotherRestaurant(Guid oldRestaurantID, Guid newRestaurantId, Dishes dish)
    {
        var oldRestaurantDb = GetById(oldRestaurantID);
        var newRestaurantDB = GetById(newRestaurantId);
        if (oldRestaurantDb is null)
        {
            return false;
        }
        var index = restaurants.IndexOf(newRestaurantDB);
        restaurants[index].Dishes.Add(dish);
        index = restaurants.IndexOf(oldRestaurantDb);
        restaurants[index].Dishes.Remove(dish);

        return true;
    }
}
