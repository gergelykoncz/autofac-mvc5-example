using DIApp.BusinessLayer.Facade;
using DIApp.Controllers;
using DIApp.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DIApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexShouldReturnValues()
        {
            // Arrange
            IEnumerable<string> countries = new List<string>() { "Andorra", "Hungary" };
            IEnumerable<Employee> employees = new List<Employee>() { new Employee() };

            Mock<IEmployeeFacade> facade = new Mock<IEmployeeFacade>();
            facade.Setup(x => x.GetEmployeeCountries()).Returns(countries);
            facade.Setup(x => x.GetEmployeesByCountry(It.IsAny<string>())).Returns(employees);
            HomeController controller = new HomeController(facade.Object);


            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<string> countryNames = result.ViewBag.Countries;

            // Assert
            Assert.AreEqual(countries, countryNames);
            Assert.AreEqual(employees, result.Model);
        }

        [TestMethod]
        public void IndexShouldPassCountryParamToFacade()
        {
            IEnumerable<Employee> employees = new List<Employee>() { new Employee() };

            Mock<IEmployeeFacade> facade = new Mock<IEmployeeFacade>();
            facade.Setup(x => x.GetEmployeesByCountry(It.IsAny<string>())).Returns(employees);
            HomeController controller = new HomeController(facade.Object);

            controller.Index("cc"); 

            facade.Verify(x => x.GetEmployeesByCountry("cc"));
        }
    }
}
