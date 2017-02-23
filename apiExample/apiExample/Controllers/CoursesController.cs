using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using School.data;
using School.data.DomainClasses;

namespace apiExample.Controllers
{
    public class CoursesController : ApiController
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/Courses
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        // GET: api/Courses/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Courses
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Courses/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Courses/5
        public void Delete(int id)
        {
        }
    }
}
