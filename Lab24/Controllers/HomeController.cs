using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab24.Models;

namespace Lab24.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            ViewBag.ItemList = ORM.Items.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SignUpForm()
        {
            return View();
        }
        public ActionResult AddNewUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
                ORM.Users.Add(newUser);
                ORM.SaveChanges();
                return RedirectToAction("Confirm");
            }
            else
            {
                ViewBag.Message = "Error! Invalid input!";
                return View();
            }

        }
        public ActionResult Confirm()
        {
            return View();
        }
        public ActionResult Admin()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            ViewBag.ItemList = ORM.Items.ToList();
            return View();
        }
        public ActionResult AddNewItem(Item newItem)
        {
            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
                ORM.Items.Add(newItem);
                ORM.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Error! Invalid input!";
                return View();
            }
        }
        public ActionResult DeleteItem(string item)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            Item Found = ORM.Items.Find(item);
            if (Found != null)
            {
                ORM.Items.Remove(Found);
                ORM.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult Error()
        {
            ViewBag.Message = "Error, invalid!";
            return View();
        }
        public ActionResult EditItem(Item newItem)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            Item oldItem = ORM.Items.Find(newItem.itemname);
            if(oldItem != null && ModelState.IsValid)
            {
                oldItem.itemname = newItem.itemname;
                oldItem.itemdescription = newItem.itemdescription;
                oldItem.itemquantity = newItem.itemquantity;
                oldItem.itemprice = newItem.itemprice;
                ORM.Entry(oldItem).State = System.Data.Entity.EntityState.Modified;
                ORM.SaveChanges();
                return View("Admin");
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult updateItem (string item)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            Item Found = ORM.Items.Find(item);
            if(Found != null)
            {
                ViewBag.Item = Found;
                return View();
            }
            else
            {
                ViewBag.Message = "Item not found";
                return View("Error");
            }
        }
    }
}