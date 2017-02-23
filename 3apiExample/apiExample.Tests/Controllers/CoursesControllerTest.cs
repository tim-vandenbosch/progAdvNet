using System;
using System.Collections.Generic;
using apiExample;
using apiExample.Controllers;
using NUnit.Framework;
using Moq;
using School.data;
using School.data.DomainClasses;

namespace apiExample.Tests.Controllers
{
    [TestFixture]
    public class CoursesControllerTest
    {
        [Test]
        public void Get_ReturnsAllCoursesFromRepository()
        {
            //Arrange
            var coursesRepositoryMock = new Mock<ICourseRepository>();
            // making a list with courses
            var allCourses = new List<Course>
            {
                new Course()
            };
            // making sure the mock gives the courses from the list
            coursesRepositoryMock.Setup(repo => repo.GetAll()).Returns(allCourses);
            // make an instance of the controller
            var controller = new CoursesController(coursesRepositoryMock.Object);

            //act
            var returnedCourses = controller.Get();

            //assert
            coursesRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            Assert.That(returnedCourses, Is.EquivalentTo(allCourses));
        }
    }
}
