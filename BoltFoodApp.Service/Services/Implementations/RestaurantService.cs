using BoltFoodApp.Core.Enums;
using BoltFoodApp.Core.Models;
using BoltFoodApp.Core.Repositories.RestaurantRepository;
using BoltFoodApp.Data.Repositories.RestaurantRepository;
using BoltFoodApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BoltFoodApp.Service.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {  
        private readonly IRestaurantRepository _restaurantRepository = new RestaurantRepository();
    
        public async Task<string> CreateAsync(string name,RestaurantCategory restaurantCategory)
        {
           Restaurant restaurant=new Restaurant(restaurantCategory,name );
           Console.ForegroundColor = ConsoleColor.DarkGreen;
            await _restaurantRepository.AddAsync(restaurant);
           return "Succesfully Created";
         }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _restaurantRepository.GetAllAsync();
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(x => x.Id == id);
            if(restaurant == null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found ");
                return null;
            }
           return restaurant;
        }

        public async Task<string> RemoveAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(x => x.Id == id);
            if(restaurant == null)
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found ");
                return null;
            }
            await _restaurantRepository.RemoveAsync(restaurant);
            return "Succesfully Removed ";
        }


        public async Task<string> UpdateAsync(int id, string name)
        {
            Restaurant restaurant=await _restaurantRepository.GetAsync(x=>x.Id == id);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found");
                return null;
            }
            restaurant.Name = name;

            await _restaurantRepository.UpdateAsync(restaurant);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully Updated";
        }
    }
}
