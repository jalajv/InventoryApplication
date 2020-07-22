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

namespace apisShopBridge.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InventoryOperationsController : ApiController
    {
        private dbShopBridgeInventoryEntities db = new dbShopBridgeInventoryEntities();

        // GET api/InventoryOperations
        
        public IQueryable<ItemList> GetItemLists()
        {
            return db.ItemLists;
        }

        // GET api/InventoryOperations/5
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

        // PUT api/InventoryOperations/5
        public IHttpActionResult PutItemList(int id, ItemList itemlist)
        {
            if (id != itemlist.id)
            {
                return BadRequest();
            }

            db.Entry(itemlist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/InventoryOperations
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
            return CreatedAtRoute("DefaultApi", new { }, result);
        }

        // POST api/InventoryOperations

        //public IHttpActionResult PostUpload(HttpContext context)
        //{
        //    //Check if Request is to Upload the File.
        //    if (context.Request.Files.Count > 0)
        //    {
        //        //Fetch the Uploaded File.
        //        HttpPostedFile postedFile = context.Request.Files[0];

        //        //Set the Folder Path.
        //        string folderPath = context.Server.MapPath("~/Uploads/");

        //        //Set the File Name.
        //        string fileName = Path.GetFileName(postedFile.FileName);

        //        //Save the File in Folder.
        //        postedFile.SaveAs(folderPath + fileName);

        //        //Send File details in a JSON Response.
                
        //        context.Response.StatusCode = (int)HttpStatusCode.OK;
        //        context.Response.ContentType = "text/json";
        //        context.Response.Write("Ok");
        //        context.Response.End();
                
        //    }
        //    return Ok();
        //}

        //public Task<HttpResponseMessage> Post()
        //{
        //    List<String> savedFilePath = new List<string>();
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }
        //    string rootpath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
        //    var provider = new MultipartFileStreamProvider(rootpath);
        //    var task = Request.Content.ReadAsMultipartAsync(provider).
        //        ContinueWith<HttpResponseMessage>(t =>
        //        {
        //            if (t.IsCanceled || t.IsFaulted)
        //            {
        //                Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
        //            }
        //            foreach (MultipartFileData item in provider.FileData)
        //            {
        //                try
        //                {
        //                    string name = item.Headers.ContentDisposition.FileName.Replace("\"","");
        //                    string newfilename = Guid.NewGuid() + Path.GetExtension(name);
        //                    File.Move(item.LocalFileName,Path.Combine(rootpath,newfilename));

        //                    Uri baseuri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
        //                    string filerelativepath = "~/uploadfiles/" + newfilename;
        //                    Uri filefullpath = new Uri(baseuri, VirtualPathUtility.ToAbsolute(filerelativepath));
        //                    savedFilePath.Add(filefullpath.ToString());
        //                }
        //                catch(Exception ex){
        //                    string message = ex.Message;
        //                }
                        

        //            }
        //            return Request.CreateResponse(HttpStatusCode.Created, savedFilePath);
        //        });
        //    return task;
        //}


        // POST api/<controller>
        /*
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            string changed_name = "";
            var httpRequest = HttpContext.Current.Request;
            bool retresult = false;

            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    int hasheddate = DateTime.Now.GetHashCode();
                    //Good to use an updated name always, since many can use the same file name to upload.
                    changed_name = hasheddate.ToString() + "_" + postedFile.FileName;

                    var filePath = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + changed_name);
                    postedFile.SaveAs(filePath); // save the file to a folder "Images" in the root of your app

                    changed_name = @"~\UploadedFiles\" + changed_name; //store this complete path to database
                    docfiles.Add(changed_name);

                }
                retresult = true;
                
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            if(httpRequest.Form.Count > 0)
            {
                ItemList objItems = new ItemList();
                objItems.Name = httpRequest.Form.Get("Name");
                objItems.Description = httpRequest.Form.Get("Description");
                objItems.Price = Convert.ToDecimal(httpRequest.Form.Get("Price"));
                objItems.ImagePath = changed_name;
                db.ItemLists.Add(objItems);
                db.SaveChanges();
                retresult = true;
                result = Request.CreateResponse(HttpStatusCode.Created, retresult);
            }
            return result;
        } */

        // DELETE api/InventoryOperations/5
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
            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemListExists(int id)
        {
            return db.ItemLists.Count(e => e.id == id) > 0;
        }
    }
}