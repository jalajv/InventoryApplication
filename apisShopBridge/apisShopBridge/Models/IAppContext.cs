using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apisShopBridge.EntityModel;

namespace apisShopBridge.Models
{
    public interface IAppContext:IDisposable
    {
        IDbSet<ItemList> ItemLists { get; }
        int SaveChanges();
        void MarkAsModified(ItemList item);
    }
}
