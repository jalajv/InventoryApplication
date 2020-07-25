using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apisShopBridge.EntityModel;

namespace WebAPIsUnitTests.DbSet
{
    class 
    TestItemDbSet:TestDbSet<ItemList>
    {
        public override ItemList Find(params object[] keyValues)
        {
            return this.SingleOrDefault(item=>item.id == (int)keyValues.Single());
        }
    }
}
