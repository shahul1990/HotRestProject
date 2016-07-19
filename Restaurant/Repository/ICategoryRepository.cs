using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Repository
{
    public interface ICategoryRepository
    {
        List<ItemCategory> findAll();
        ItemCategory find(int id);

    }
}
