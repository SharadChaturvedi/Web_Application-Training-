using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assesment_2.Models;

namespace Assesment_2.Controllers
{
    public class CodeController : Controller
    {

        public NorthwindEntities db = new NorthwindEntities();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        //-->1. First action method should return all customers residing in Germany
        public ActionResult CustomerInGermany()
        {
            var CustomerInGermany = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(CustomerInGermany);
        }

        //-->  2. Second action method should return customer details with an orderId==10248
        public ActionResult CustomerDetails()
        {
            var Cd = db.Orders
                .Where(c => c.OrderID == 10248)
                .Select(c => c.Customer)
                .FirstOrDefault();

            return View(Cd);
        }
    }
}