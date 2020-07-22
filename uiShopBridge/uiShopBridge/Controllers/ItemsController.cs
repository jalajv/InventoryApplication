using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uiShopBridge.Controllers
{
    public class ItemsController : Controller
    {
        /* Returns the index view of ShopBridgeInventory App */ 
        // GET: /Items/
        public ActionResult Index()
        {
            return View();
        }
        /* Return the ItemDetails view of ShopBridgeInventory App  */
        public ActionResult ItemDetails()
        {
            return View();
        }
	}
}