using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Repository
{
    public interface IProductRepository
    {
        List<ItemList> LatestProd(int n);
        List<ItemList> RelatedProd(ItemList itemlist, int n);
        ItemList find(int id);
    }
}
