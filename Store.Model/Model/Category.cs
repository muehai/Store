using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Model.Model
{
    public class Category
    {
        public int  CategoryId { get; set; }
        public string  Name { get; set; }
        public DateTime? DateCreated { get; set; } //Nullable 
        public DateTime? DateUpdated { get; set; } //Nullable
        public virtual List<Gadget> Gadgets  { get; set; }

        public Category()
        {
            DateCreated = DateTime.Now;
        }

    }
}
