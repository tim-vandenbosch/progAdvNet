using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using School.data;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace apiExample.Api
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<ICourseRepository, CourseDbRepository>(Lifestyle.Scoped);

            // optional, to check for errors
            container.Verify();

            // making our own dependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}