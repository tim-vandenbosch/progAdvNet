using System.Collections;
using System.Collections.Generic;
using OdeToFood.Data.DomainClasses;

namespace OdeToFood.Data
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurantIfExists(int id);
    }
}
