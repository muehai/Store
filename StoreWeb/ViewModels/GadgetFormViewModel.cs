using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.HttpPostedFileBase;


namespace StoreWeb.ViewModels
{
    public class GadgetFormViewModel
    {
        public string File { get; set; }
        public string GadgetTitle { get; set; }
        public string GadgetDescription { get; set; }
        public decimal GadgetPrice { get; set; }
        public int GadgetCategory { get; set; }
    }

}
