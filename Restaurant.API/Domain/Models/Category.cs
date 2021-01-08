using System.Collections.Generic;

namespace Restaurant.API.Domain.Models
{
    public class Category
    {
        public int id {get; set;}
        public string short_name {get; set;}
        public string name {get; set;}
        public string special_instructions {get; set;}
        public string url {get; set;}
        
        public IList<MenuItems> menu_items {get; set;} = new List<MenuItems>();

    }
}