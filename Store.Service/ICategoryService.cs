using System;
using System.Collections.Generic;
using System.Text;
using Store.Data;
using System.Linq;
using Store.Model.Model;
using Store.Data.Repositories;
using Store.Data.Infrastracture;

namespace Store.Service
{
    //The service of Category obj 
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category category);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region CategorySerive Members

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (!String.IsNullOrEmpty(name))
            {
                return categoryRepository.GetAll(); //Get the name of last
            }
            else
            {
                return categoryRepository.GetAll().Where( g => g.Name == name);
            }
        }

       public void CreateCategory(Category category)
        {
            categoryRepository.Add(category);
        }
        public void SaveCategory()
        {
            unitOfWork.Commit();

        }
        public Category GetCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            return category;
        }
        public Category GetCategory(string name)
        {
            var category = categoryRepository.GetCategoryByName(name);
            return category;
        }
        #endregion





    }

}
