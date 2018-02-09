using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Store.Model.Model;
using Store.Data.Repositories;
using Store.Data.Infrastracture;

namespace Store.Service
{
    public interface IGadgetService
    {
        //Get the Gadget obj
        IEnumerable<Gadget> GetGadget();
        IEnumerable<Gadget> GetCategoryGadgetByName(string categoryname, string gadgetname);
        Gadget GetGadgeById(int id); // Get Gadget instance by Id
        void CreateGadget(Gadget gadget); //Create Gadget obj
        void SaveGadget(); //Commit the change the 
    }


    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository gadgetRepository; // the nenss
        private readonly ICategoryRepository categoryRepository; //  Get the category
        private readonly IUnitOfWork unitOfWork; //Commit the database 

        //Create the constractor

        public GadgetService(IGadgetRepository gadgetRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.gadgetRepository = gadgetRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork; 

        }

        #region IGadgetService Members

        public IEnumerable<Gadget> GetGadget()
        {
            var gadget = gadgetRepository.GetAll();
            return gadget;
        }
       public IEnumerable<Gadget> GetCategoryGadgetByName(string categoryname, string gadgetname)
        {
            var category = categoryRepository.GetCategoryByName(categoryname);
            return category.Gadgets.Where(g => g.Name.ToLower().Contains(gadgetname.ToLower().Trim()));

        }
        public Gadget GetGadgeById(int id)
        {
            var gadget = gadgetRepository.GetById(id);
            return gadget;
        }
        //Create the gagde 
        public void CreateGadget(Gadget gadget) 
        {
            gadgetRepository.Add(gadget);
        }
        //
        public void SaveGadget() 
        {
            unitOfWork.Commit();
        }

        #endregion

    }

}
