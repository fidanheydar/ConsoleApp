using BoltFoodApp.Core.Enums;
using BoltFoodApp.Core.Models;
using BoltFoodApp.Core.Repositories.RestaurantRepository;
using BoltFoodApp.Data.Repositories.RestaurantRepository;
using BoltFoodApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFoodApp.Service.Services.Implementations
{ 
    public  class ProductService:IProductService
    {
        private readonly IRestaurantRepository _restaurantRepository = new RestaurantRepository();


        public  async Task<string> CreateAsync(string name,int idRestoran ,double price, ProductCategory productCategory)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(x => x.Id == idRestoran);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found ");
                return null; ;
            }
            Product product = new Product(productCategory,name,price,restaurant);
            restaurant.Products.Add(product);
            Console.ForegroundColor = ConsoleColor.Blue;
            return "Successful";
        }

        public  async Task<List<Product>> GetAllAsync( )
        {
          List<Restaurant> Restaurants =await _restaurantRepository.GetAllAsync();
            List<Product> Products = new List<Product>();
            foreach(var item in Restaurants)
            {
                Products.AddRange(item.Products);   
            }
            return Products;

        }

        public async  Task<Product> GetAsync(int id)
        {
            List<Restaurant> Restaurants = await _restaurantRepository.GetAllAsync();
            List<Product> Products= await GetAllAsync();

            if(Products.Count == 0)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("There is not any product");
                return null;
            }


            foreach(var item in Restaurants)
            {
                Product product=item.Products.Find(x => x.Id == id);
                if(product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public  async Task<string> RemoveAsync(int id)
        {
            List<Restaurant> Restaurant =await _restaurantRepository.GetAllAsync();
            foreach(var item in Restaurant )
            {
                Product product=item.Products.Find(x=>x.Id == id);
                if(product != null)
                {
                    item.Products.Remove(product);
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Successfully removed";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Product is not Found";
        } 

        public  async Task<string> UpdateAsync(int id, string name, double price)
        {
            List<Restaurant> Restaurants = await _restaurantRepository.GetAllAsync();
            List<Product> Products=await GetAllAsync();
            if(Products.Count==0) 
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                return "There is not any product";
            }
            foreach(var item in Restaurants)
            {
                Product product=item.Products.Find(x => x.Id == id);
                if(product != null)
                {
                    product.Name= name;
                    product.Price= price;
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Successfully updated";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Error occured.Product is not found";
        }
    }
}
