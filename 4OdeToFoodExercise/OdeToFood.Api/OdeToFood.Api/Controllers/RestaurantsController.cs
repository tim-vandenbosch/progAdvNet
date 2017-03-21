﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        }

        // PUT: api/Restaurants/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Restaurants/5
        public void Delete(int id)
        {
        }

        public IHttpActionResult GetAllRestaurants()
        {
            return Ok(_repository.GetAllRestaurants());
        }

        public IHttpActionResult GetRestaurantIfExists(int restaurantId)
        {
            return Ok(_repository.GetRestaurantIfExists(restaurantId));
        }
    }
}
