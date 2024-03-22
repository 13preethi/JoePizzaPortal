using JoePizzaPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaLibrary;

namespace JoePizzaPortal.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public PizzaDAL dal;
        public PizzaController()
        {
            dal = new PizzaDAL();
        }
        public ActionResult Index(string item)
        {
            List<Pizza> plist = dal.PizzaDetails();
            List<PizzaModel> modellist = new List<PizzaModel>();
            foreach (Pizza pizza in plist)
            {
                PizzaModel model = new PizzaModel() { Id = pizza.Id, Type = pizza.Type, Price = pizza.Price };
                modellist.Add(model);
            }
            if (modellist == null)
            {
                return View(new List<PizzaModel>());
            }

            var searchResults = modellist
                .Where(i => i.Type != null && (item == null || i.Type.ToLower().Contains(item.ToLower())))
                .Select(i => new PizzaModel { Id = i.Id, Type = i.Type, Price = i.Price })
                .ToList();

            ViewBag.SearchTerm = item;

            return View(searchResults);
        }
        public ActionResult SelectedItem(int id)
        {
            int food_id = id;
            List<Pizza> plist = dal.PizzaDetails();
            Pizza item = plist.Find(p => p.Id == food_id);
            PizzaModel model = new PizzaModel() { Id = item.Id, Type = item.Type, Price = item.Price };
            TempData["Price"] = model.Price;
            TempData["Type"] = model.Type;
            TempData.Keep();
            return View(model);
        }

        [HttpPost]
        public ActionResult SelectedItem(int qty,int id)
        {
            if (TempData["Type"] != null && TempData["Price"] != null)
            {
                string fooditem = TempData["Type"].ToString();
                float price = Convert.ToSingle(TempData["Price"]);
                float Total_Amt = price * qty;
                TempData["Total_amt"] = Total_Amt;
                TempData.Keep();
                return RedirectToAction("PaymentMode");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult PaymentMode()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = 10;
            string randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            TempData["orderid"] = randomString;
            ViewBag.TotalAmt = Convert.ToDouble(TempData["Total_amt"]);



            return View();
        }
        public ActionResult OrderSuccess()
        {
            TempData["RandomOrderId"] = TempData["orderid"];
            return View("OrderSuccess");
        }

    }
}