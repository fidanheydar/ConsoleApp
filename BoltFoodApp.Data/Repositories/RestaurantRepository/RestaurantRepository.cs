using BoltFoodApp.Core.Models;
using BoltFoodApp.Core.Repositories.RestaurantRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFoodApp.Data.Repositories.RestaurantRepository
{
    public  class RestaurantRepository:Repository<Restaurant>,IRestaurantRepository
    {
    }
}
