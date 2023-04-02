using BoltFoodApp.Core.Enums;
using BoltFoodApp.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFoodApp.Core.Models
{
    public  class Product:BaseModel
    {
        private static int _id;   
        public ProductCategory ProductCategory { get; set; }
    public Restaurant Restaurant { get; set; }  
        public string Name { get; set; }

        public double Price { get; set; }
        public Product(ProductCategory productCategory,string name,double price,Restaurant restaurant)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            ProductCategory=productCategory;
            Restaurant=restaurant;
        }
    }
}
