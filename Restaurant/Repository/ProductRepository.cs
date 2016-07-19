using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Models;

namespace Restaurant.Repository
{
    public class ProductRepository : IProductRepository
    {
        private RestaurantDBEntities RestaurantDBEntities = new RestaurantDBEntities();

        public ItemList find(int id)
        {
            return RestaurantDBEntities.ItemLists.Find(id);
        }
        
        public List<ItemList> LatestProd(int n)
        {
            return RestaurantDBEntities.ItemLists.OrderBy(p => p.id).Take(n).ToList();
        }


        public List<ItemList> RelatedProd(ItemList itemlist, int n)
        {
            return RestaurantDBEntities.ItemLists.Where(p => p.Category_id == itemlist.Category_id && p.id != itemlist.id).Take(n).ToList(); 
        }
    }
}