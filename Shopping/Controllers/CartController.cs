using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class CartController : Controller
    {
        CartContext ctx;

        private static Cart theCart = new Cart();

        public CartController() : base()
        {
            ctx = new CartContext();
        }

        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.CartCount = theCart.GetCount();
            ViewBag.CartTotal = theCart.CalculateTotal();
            return View(ctx.productSet);
        }

        public ActionResult AddToCart(string code)
        {
            try
            {
                Product p = ctx.productSet.FirstOrDefault(x => x.Code.Equals(code));
                if (p!=null)
                {
                    theCart.AddItem(p);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                var x = collection.Count;
                Product p = new Product();
                p.Code = collection["Code"];
                p.Description = collection["Description"];
                p.Price = Double.Parse(collection["Price"]);

                ctx.productSet.Add(p);
                ctx.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
