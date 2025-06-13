using Services;
using Models;
using System.Collections.Generic;

namespace Application
{
    public class CategoryController
    {
        private readonly CarStoreService _service;

        public CategoryController(CarStoreService service)
        {
            _service = service;
        }

        public void AddCategory(Category category) => _service.AddCategory(category);
        public List<Category> GetAllCategories() => _service.GetAllCategories();
    }
}
