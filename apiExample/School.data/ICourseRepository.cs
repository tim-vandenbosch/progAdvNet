using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.data.DomainClasses;

namespace School.data
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
    }
}
