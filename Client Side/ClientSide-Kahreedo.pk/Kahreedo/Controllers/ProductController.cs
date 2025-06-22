using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Khareedo.Models;
using PagedList;
using PagedList.Mvc;

namespace Khareedo.Controllers
{
    public class ProductController : Controller
    {
        KhareedoEntities db = new KhareedoEntities();


        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();

            

            return View("Products");
        }

        

        //ADD TO CART
        public ActionResult AddToCart(int id)
        {
            OrderDetail OD = new OrderDetail();
            OD.ProductID = id;
            int Qty = 1;
            decimal price = db.Products.Find(id).UnitPrice;
            OD.Quantity = Qty;
            OD.UnitPrice = price;
            OD.TotalAmount = Qty * price;
            OD.Product = db.Products.Find(id);

            if (TempShpData.items == null)
            {
                TempShpData.items = new List<OrderDetail>();
            }
            TempShpData.items.Add(OD);
            
            return Redirect(TempData["returnURL"].ToString());

        }

        //VIEW DETAILS
        public ActionResult ViewDetails(int id)
        {
            var prod = db.Products.Find(id);
            var reviews = db.Reviews.Where(x => x.ProductID == id).ToList();
            ViewBag.Reviews = reviews;
            ViewBag.TotalReviews = reviews.Count();
            ViewBag.RelatedProducts = db.Products.Where(y => y.CategoryID == prod.CategoryID).ToList();
            

            var ratedProd=db.Reviews.Where(x => x.ProductID == id).ToList();
            int count = ratedProd.Count();
            int TotalRate =  ratedProd.Sum(x => x.Rate).GetValueOrDefault();
            ViewBag.AvgRate = TotalRate > 0 ? TotalRate / count : 0;

            this.GetDefaultData();
            return View(prod);
        }

        //WISHLIST
        public ActionResult WishList(int id)
        {
            
            Wishlist wl = new Wishlist();
            wl.ProductID = id;
            wl.CustomerID = TempShpData.UserID;

            db.Wishlists.Add(wl);
            db.SaveChanges();
           
            ViewBag.WlItemsNo = db.Wishlists.Where(x => x.CustomerID == TempShpData.UserID).ToList().Count();
            if (TempData["returnURL"].ToString()=="/")
            {
                return RedirectToAction("Index","Home");
            }
            return Redirect(TempData["returnURL"].ToString());
        }

        


        public ActionResult Products(int subCatID)
        {
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();
            var prods = db.Products.Where(y => y.SubCategoryID == subCatID).ToList();
            return View(prods);
        }

        //GET PRODUCTS BY CATEGORY
        public ActionResult GetProductsByCategory(string categoryName, int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();
            
            var prods = db.Products.Where(x => x.Category.Name == categoryName).ToList();
            return View("Products", prods.ToPagedList(page ?? 1, 9));
        }

        //SEARCH BAR
        public ActionResult Search(string product,int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();
            

            List<Product> products;
            if (!string.IsNullOrEmpty(product))
            {
                products = db.Products.Where(x => x.Name.StartsWith(product)).ToList();
            }
            else
            {
                products = db.Products.ToList();
            }
            return View("Products", products.ToPagedList(page ?? 1,6));
        }

        public JsonResult GetProducts(string term)
        {
            List<string> prodNames = db.Products.Where(x => x.Name.StartsWith(term)).Select(y => y.Name).ToList();
            return Json(prodNames, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FilterByPrice(int minPrice,int maxPrice,int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();
            
            ViewBag.filterByPrice = true;
           var filterProducts= db.Products.Where(x => x.UnitPrice >= minPrice && x.UnitPrice <= maxPrice).ToList();
           return View("Products", filterProducts.ToPagedList(page ?? 1, 9));
        }

       
    }
}