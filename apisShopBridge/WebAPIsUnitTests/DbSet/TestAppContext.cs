using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apisShopBridge.EntityModel;
using apisShopBridge.Models;
using System.Data.Entity;

namespace WebAPIsUnitTests.DbSet
{
    public class TestAppContext:IAppContext
    {
        public TestAppContext()
        {
            this.ItemLists = new TestItemDbSet();
        }

        public IDbSet<ItemList> ItemLists { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(ItemList item) { }
        public void Dispose() { }
 

    }
}
