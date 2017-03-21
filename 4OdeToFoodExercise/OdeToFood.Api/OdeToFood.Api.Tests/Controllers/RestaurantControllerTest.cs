using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using OdeToFood.Api.Controllers;
using OdeToFood.Data;
using OdeToFood.Data.DomainClasses;

namespace OdeToFood.Api.Tests.Controllers
{
    [TestFixture]
    public class RestaurantControllerTest
    {
        [Test]
        public void Get_ReturnsAllRestaurantsFromRepository()
        {
            // assign
            var controller = TestableRestaurantController.CreateInstance();
            var allRestaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = new Random().Next(1,100)*100,
                    City = "Leuven",
                    Country = "Belgium",
                    Name = "Chéz Marcel"
                }
            };
            controller.RestaurantRepositoryMock.Setup(repo => repo.GetAllRestaurants()).Returns(allRestaurants);
            
            // act
            var returnedRestaurants = controller.GetAllRestaurants();

            // assert
            controller.RestaurantRepositoryMock.Verify(repo => repo.GetAllRestaurants(), Times.Once); // check so the function is just called once
            Assert.That(returnedRestaurants, Is.EquivalentTo(allRestaurants)); // check if values are correct
            Assert.That(returnedRestaurants, Is.EquivalentTo(OkResult = allRestaurants));
        }

        [Test]
        public void Get_ReturnsRestaurantIfItExists()
        {
            // assign
            var restaurantRepositoryMock = new Mock<IRestaurantRepository>();
            var restaurant = new Restaurant();
            restaurantRepositoryMock.Setup(repo => repo.GetRestaurantIfExists(1)).Returns(restaurant);
            var controller = new RestaurantsController(restaurantRepositoryMock.Object);

            // act
            var returnedRestaurant = controller.GetRestaurantIfExists(1);

            // assert
            Assert.That(returnedRestaurant, Is.EqualTo(restaurant));
        }

        private class TestableRestaurantController : RestaurantsController
        {
            public Mock<IRestaurantRepository> RestaurantRepositoryMock { get; set; }
            public TestableRestaurantController(Mock<IRestaurantRepository> restaurantRepository) : base(restaurantRepository.Object)
            {
                RestaurantRepositoryMock = restaurantRepository;
            }

            public static TestableRestaurantController CreateInstance()
            {
                var restaurantRepositoryMock = new Mock<IRestaurantRepository>();
                return new TestableRestaurantController(restaurantRepositoryMock);
            }
        }
    }
}