using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Store.Model.Model;
using Store.Service;
using StoreWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.IO;

namespace StoreWeb.Controllers
{
    public class StoresController : Controller
    {
        //Access a file
        private IHostingEnvironment _environment;
        //Add services
        private readonly ICategoryService categoryService;
        private readonly IGadgetService gadgetService;
        private readonly IMapper mapper;

        //Pass the DI for the services
        StoresController(ICategoryService categoryService, IGadgetService gadgetService)
        {
            this.categoryService = categoryService;
            this.gadgetService = gadgetService;
            
        }

        public StoresController(IHostingEnvironment _environment)
        {
            this._environment = _environment;

        }


        //Index 
        public IActionResult Index(string category = null)
        {
            IEnumerable<CategoryViewModel> viewModelGadgets;
            IEnumerable<Category> categories;

            categories = categoryService.GetCategories(category).ToList();

            viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return  View(viewModelGadgets);   
        }

        //Get the Gadgets by category and name
        public IActionResult Filter(string category, string gadgetName)
        {
            IEnumerable<GadgetsViewModel> viewModelGadgets;
            IEnumerable<Gadget> gadgets;

            gadgets = gadgetService.GetCategoryGadgetByName(category, gadgetName);

            viewModelGadgets = Mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetsViewModel>>(gadgets);

            return View(viewModelGadgets);


        }

        //Add new Gadgets items
        [HttpPost]
        public async Task<IActionResult> Create(GadgetFormViewModel newGadget, ICollection<IFormFile> files)
        {
            if (newGadget != null && newGadget.File != null)
            {
                var gadget = Mapper.Map<GadgetFormViewModel, Gadget>(newGadget);
                gadgetService.CreateGadget(gadget);

                string gadgetPicture = System.IO.Path.GetFileName(newGadget.File);


                var  uploads = System.IO.Path.Combine(_environment.WebRootPath, gadgetPicture);

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName),FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                    }
                }
                //newGadget.File.SaveAs(path);
                gadgetService.SaveGadget();

            }

            var category = categoryService.GetCategory(newGadget.GadgetCategory);
            return RedirectToAction("Index", new { category = category.Name });
        }

    }
}