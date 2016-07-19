using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Models;

namespace Restaurant.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private RestaurantDBEntities RestaurantDBEntities = new RestaurantDBEntities();

        public List<ItemCategory> findAll()
        {
            return RestaurantDBEntities.ItemCategories.ToList();
        }

        public ItemCategory find(int id)
        {
            return RestaurantDBEntities.ItemCategories.Find(id);
        }

        //List<ItemCategory> ICategoryRepository.findAll()
        //{
        //    throw new NotImplementedException();
        //}

        //ItemCategory ICategoryRepository.find(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}