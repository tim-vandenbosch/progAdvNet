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
        private class TestableRestaurantController : RestaurantsController
        {
            public TestableRestaurantController(Mock<IRestaurantRepository> restaurantRepository)
                : base(restaurantRepository.Object)
            {
                RestaurantRepositoryMock = restaurantRepository;
            }

            public Mock<IRestaurantRepository> RestaurantRepositoryMock { get; }

            public static TestableRestaurantController CreateInstance()
            {
                var restaurantRepositoryMock = new Mock<IRestaurantRepository>();
                return new TestableRestaurantController(restaurantRepositoryMock);
            }
        }

        [Test]
        public void Get_ReturnsAllRestaurantsFromRepository()
        {
            // assign
            var controller = TestableRestaurantController.CreateInstance();
            var allRestaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 10,
                    City = "Leuven",
                    Country = "Belgium",
                    Name = "Chéz Marcel"
                }
            };
            controller.RestaurantRepositoryMock.Setup(repo => repo.GetAllRestaurants()).Returns(allRestaurants);
            // act
            var returnedRestaurants =
                    controller.GetAllRestaurants() as OkNegotiatedContentResult<IEnumerable<Restaurant>>;
                // get the result and put it in a 200(okResult) with content
            // assert
            // I want to get 200 code with a list/single item in the body
            controller.RestaurantRepositoryMock.Verify(repo => repo.GetAllRestaurants(), Times.Once);
                // check so the function is just called once
            Assert.That(returnedRestaurants, Is.Not.Null); // check if it gives something back
            Assert.That(returnedRestaurants.Content, Is.EquivalentTo(allRestaurants));
                // check if it gives the same back as it gets
        }

        [Test]
        public void Get_ReturnsRestaurantIfItExists()
        {
            // assign
            var controller = TestableRestaurantController.CreateInstance();
            var restaurant = new Restaurant
            {
                Id = 10,
                City = "Leuven",
                Country = "Belgium",
                Name = "Chéz Marcel"
            };
            controller.RestaurantRepositoryMock.Setup(repo => repo.GetRestaurantIfExists(10)).Returns(restaurant);

            // act
            var returnedRestaurant =
                controller.GetRestaurantIfExists(10) as OkNegotiatedContentResult<Restaurant>;

            // assert
            Assert.That(returnedRestaurant, Is.Not.Null); // I don't want my result to be empty
            Assert.That(returnedRestaurant.Content, Is.EqualTo(restaurant)); // I want to get my restaurant
        }
    }
}