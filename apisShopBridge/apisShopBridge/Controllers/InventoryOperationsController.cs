using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using apisShopBridge.EntityModel;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using apisShopBridge.Models;

namespace apisShopBridge.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InventoryOperationsController : ApiController
    {
        private IAppContext db = new dbShopBridgeInventoryEntities();

        public InventoryOperationsController() 
        {
            
        }
        public InventoryOperationsController(IAppContext context)
        {
            db = context;
        }

        #region GetItemLists

        // GET api/InventoryOperations
        /* Returns the list of all the items */
        public IQueryable<ItemList> GetItemLists()
        {
            return db.ItemLists;
        }

        #endregion

        #region GetItemList(int id)
        // GET api/InventoryOperations/5
        /* Get specific item details based on param id */ 
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult GetItemList(int id)
        {
            ItemList itemlist = db.ItemLists.Find(id);
            if (itemlist == null)
            {
                return NotFound();
            }

            return Ok(itemlist);
        }

        #endregion

        #region PostItemList
        // POST api/InventoryOperations
        /* Save the Item details returns true if item is successfully inserted else false */ 
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult PostItemList(ItemList itemlist)
        {
            bool result;
            if (itemlist == null)
            {
                result = false;
                return NotFound();
            }
            else
            {
                db.ItemLists.Add(itemlist);
                db.SaveChanges();
                result = true;
            }
            return CreatedAtRoute("DefaultApi", new { id = itemlist.id }, itemlist);
            
        }

        #endregion PostItemList

        #region DeleteItemList

        // DELETE api/InventoryOperations/5
        /* Remove an item from db table */ 
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult DeleteItemList(int id)
        {
            bool result;
            ItemList itemlist = db.ItemLists.Find(id);
            if (itemlist == null)
            {
                result = false;
                return NotFound();
            }
            else
            {
                db.ItemLists.Remove(itemlist);
                db.SaveChanges();
                result = true;
            }
            return Ok(itemlist);
        }

        #endregion

        #region Dispose DB
        /* To Dispose DB connection */ 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

    }
}