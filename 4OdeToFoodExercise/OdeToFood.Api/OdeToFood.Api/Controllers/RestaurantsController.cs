using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OdeToFood.Data;
using OdeToFood.Data.DomainClasses;

namespace OdeToFood.Api.Controllers
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantRepository _repository;
        public RestaurantsController(IRestaurantRepository restaurantRepository)
        {
            _repository = restaurantRepository;
        }

        // GET: api/Restaurants
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Restaurants/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Restaurants
        public void Post([FromBody]string value)
        {
            if (!ModelState.IsValid)
            {
                
            }
        }

        // PUT: api/Restaurants/5
        public IHttpActionResult Put(int id, [FromBody]Restaurant restaurant)
        {
            //if id == null -> return notfound
            //if (!modelstat.isvalid)
            if (id != restaurant.Id) return NotFound();
            // restaurant.update(restaurant)
            return Ok();
        }

        // DELETE: api/Restaurants/5
        public void Delete(int id)
        {
        }

        public IHttpActionResult GetAllRestaurants()
        {
            return Ok(_repository.GetAllRestaurants());
        }

        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult GetRestaurantIfExists(int restaurantId)
        {
            return Ok(_repository.GetRestaurantById(restaurantId));
        }
    }
}
