using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Store.Data
{
    public static class StoreSeedData
    {

        public static void SeedStor(StorEntities context)
        {
            GetCategorryList().ForEach(c => context.Categories.Add(c));
            GetGadgetList().ForEach(c =>  context.Gadgets.Add(c));

            context.SaveChanges();
        } 

        private static List<Category> GetCategorryList()
        {
            return new List<Category>
        {
            new Category { Name = "Tablets" },
            new Category { Name ="laptops" },
            new Category { Name = "Mobile" }
            
        };
          }

        private static List<Gadget> GetGadgetList()
        {
            return new List<Gadget>
        {
            new Gadget{ Name= "Dragon Touch® Y88X 7", CategoryID = 1},
            new Gadget { Name ="Samsung Galaxy", CategoryID=1},
            new Gadget { Name = "euTab® N7 Pro 7", CategoryID =2},
            new Gadget { Name ="Alldaymall A88X 7", CategoryID = 2 }
            

        };
        }
    }
}
