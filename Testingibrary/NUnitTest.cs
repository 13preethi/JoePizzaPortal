using NUnit.Framework;
using NUnit.Framework.Legacy;
using JoePizzaPortal.Controllers;
using System.Web.Mvc;
using JoePizzaPortal.Models;

namespace Testingibrary
{
    [TestFixture]
    public class NUnitTest
    { 

    [Test]
        public void TestPizzaSelectionPage()
        {
            PizzaController controller = new PizzaController();
            var result = controller.SelectedItem(1) as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotNull(result.Model);
            ClassicAssert.IsInstanceOf(typeof(PizzaModel), result.Model);
        }

        [Test]
        public void TestOrderCheckoutPage()
        {
            PizzaController controller = new PizzaController();
            controller.TempData["Total_amt"] = 90.00;
            var result = controller.PaymentMode() as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotNull(result.ViewBag.TotalAmt);
           
        }
        [Test]
        public void TestOrderConfirmationPage()
        {
            string expected = "OrderSuccess";
            PizzaController controller = new PizzaController();
            var result = controller.OrderSuccess() as ViewResult;
            ClassicAssert.AreEqual(expected, result.ViewName);
        }

    }
}
