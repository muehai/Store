using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Model.Model
{
    public class Gadget
    {
        public int  GadgetId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CategoryID { get; set; }
        public  Category category { get; set; }
    }
} 
