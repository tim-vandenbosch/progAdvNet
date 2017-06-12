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
        private TestableRestaurantController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = TestableRestaurantController.CreateInstance();
        }

        [Test]
        public void Get_ReturnsAllRestaurantsFromRepository()
        {
            // assign
            // var controller = TestableRestaurantController.CreateInstance();
            var allRestaurants = new List<Restaurant>
            {
                new RestaurantBuilder().Build()
            };
            _controller.RestaurantRepositoryMock.Setup(repo => repo.GetAllRestaurants()).Returns(allRestaurants);
            // act
            var returnedRestaurants =
                    _controller.GetAllRestaurants() as OkNegotiatedContentResult<IEnumerable<Restaurant>>;
                // get the result and put it in a 200(okResult) with content
            // assert
            // I want to get 200 code with a list/single item in the body
            _controller.RestaurantRepositoryMock.Verify(repo => repo.GetAllRestaurants(), Times.Once);
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
            var restaurant = new RestaurantBuilder().WithID().Build();
            controller.RestaurantRepositoryMock.Setup(repo => repo.GetRestaurantById(restaurant.Id)).Returns(restaurant);

            // act
            var returnedRestaurant =
                controller.GetRestaurantIfExists(10) as OkNegotiatedContentResult<Restaurant>;

            // assert
            Assert.That(returnedRestaurant, Is.Not.Null); // I don't want my result to be empty
            Assert.That(returnedRestaurant.Content, Is.EqualTo(restaurant)); // I want to get my restaurant
        }

        [Test]
        public void Get_ReturnsNotFoundIfItDoesNotExists()
        {
            // assign
            // act
            // assert
            // Assert.That(NotFoundResult, Is.Not.Null);
            Assert.Fail();
        }

        [Test]
        public void Post_ValidRestaurantIsSavedInRepository()
        {
            Assert.Fail();
        }

        [Test]
        public void Post_InValidRestaurantModelStateCausesBadRequest()
        {
            Assert.Fail();
        }

        [Test]
        public void Put_ExistingRestaurantIsSavedInRepository()
        {
            var aRestaurant = new RestaurantBuilder().WithID().Build();

            _controller.RestaurantRepositoryMock.Setup(r => r.GetRestaurantById(aRestaurant.Id))
                .Returns(() => aRestaurant);

            // var okResult = _controller.Put(aRestaurant.)

            // Assert.That();
        }

        [Test]
        public void Put_NonExistingRestaurantReturnsNotfound()
        {
            // set what we want to get.
            _controller.RestaurantRepositoryMock.Setup(repo => repo.GetRestaurantById(It.IsAny<int>())).Returns(() => null);
            // make restaurant
            var aRestaurant = new RestaurantBuilder().WithID().Build();
            // notfound = controller.Responce
            var notFoundResponce = _controller.Put(aRestaurant.Id, aRestaurant) as NotFoundResult;
            // assert notfound
            Assert.That(notFoundResponce, Is.Not.Null);
        }

        [Test]
        public void Put_InvalidRestaurantModelStateCausesBadRequest()
        {
            // controller modelstate addmodelerror
            // new restaurant
            // badrequestresult = controller.put(arestaurant.id, arestaurant) as badrequestresult
            // assert badrequestresult, isnotnull
        }

        [Test]
        public void Put_MismatchBetweenUrlIdAndRestaurantIdCausesBadRequest()
        {
            // make nuw restaurant
            // badrequestresult = controller.put(0, arestaurant) as badrequestresult
            // assert baddrequest isnotnull
        }

        [Test]
        public void Delete_ExistingRestaurantIsDeletedFromRepository()
        {
            Assert.Fail();
        }

        [Test]
        public void Delete_NonExistingRestaurantReturnsNotFound()
        {
            // assert check that delete never happens
        }

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

        private class RestaurantBuilder
        {
            private readonly Restaurant _restaurant;
            private readonly Random _random;

            public RestaurantBuilder()
            {
                _restaurant = new Restaurant()
                {
                    City = Guid.NewGuid().ToString(),
                    Country = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString()
                };
            }

            public Restaurant Build()
            {
                return _restaurant;
            }

            public RestaurantBuilder WithID()
            {
                _restaurant.Id = _random.Next();
                return this;
            }
        }
    }
}