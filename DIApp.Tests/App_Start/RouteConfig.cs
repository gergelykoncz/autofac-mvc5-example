using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using System.Web.Routing;

namespace DIApp.Tests.App_Start
{
    [TestClass]
    public class RouteConfig
    {
        private RouteCollection routes;

        [TestInitialize]
        public void Init()
        {
            routes = new RouteCollection();
            DIApp.RouteConfig.RegisterRoutes(routes);
        }

        [TestMethod]
        public void HomeIndexRoute()
        {
            var expectedRoute = new { controller = "Home", action = "Index", country = "usa" };
            RouteAssert.HasRoute(routes, "/home/index/usa", expectedRoute);
        }
    }
}
