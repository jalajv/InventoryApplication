using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apisShopBridge.Controllers;
using apisShopBridge.EntityModel;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Results;
using WebAPIsUnitTests.DbSet;


namespace WebAPIsUnitTests.Controllers
{
    
    [TestClass]
    public class InventoryOperationsControllerTests
    {

        [TestMethod]
        public void GetItemList_ShouldReturnItemWithSameId()
        {
            /* Arrange */
            var context = new TestAppContext();
            context.ItemLists.Add(GetDemoItems());

            /* Act */
            var controller = new InventoryOperationsController(context);
            var result = controller.GetItemList(3) as OkNegotiatedContentResult<ItemList>;

            /* Assert */
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.id);
        }
        [TestMethod]
        public void PostItem_ShouldReturnSameItem()
        {
            var controller = new InventoryOperationsController(new TestAppContext());
            var item = GetDemoItems();

            var result = controller.PostItemList(item) as CreatedAtRouteNegotiatedContentResult<ItemList>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.id);
            Assert.AreEqual(result.Content.Name, item.Name);
        }

        [TestMethod]
        public void GetItemLists_ShouldReturnAllItems()
        {
            var context = new TestAppContext();
            context.ItemLists.Add(new ItemList { id = 1, Name = "Demo1", Description = "Demo Desc1", ImagePath = "", Price = 10 });
            context.ItemLists.Add(new ItemList { id = 2, Name = "Demo2", Description = "Demo Desc2", ImagePath = "", Price = 15 });
            context.ItemLists.Add(new ItemList { id = 3, Name = "Demo3", Description = "Demo Desc3", ImagePath = "", Price = 20 });

            var controller = new InventoryOperationsController(context);
            var result = controller.GetItemLists() as TestItemDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteItem_ShouldReturnOk()
        {
            var context = new TestAppContext();
            var item = GetDemoItems();
            context.ItemLists.Add(item);

            var controller = new InventoryOperationsController(context);
            var result = controller.DeleteItemList(3) as OkNegotiatedContentResult<ItemList>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.id, result.Content.id);
        }

        ItemList GetDemoItems()
        {
            return new ItemList() { id=3,Name="Demo Name",Price=3,ImagePath="",Description="Demo Description" };
        }

    }
}

