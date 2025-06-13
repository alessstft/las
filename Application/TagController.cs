using Services;
using Models;
using System.Collections.Generic;

namespace Application
{
    public class TagController
    {
        private readonly CarStoreService _service;

        public TagController(CarStoreService service)
        {
            _service = service;
        }

        public void AddTag(Tag tag) => _service.AddTag(tag);
        public void AddProductTag(ProductTag pt) => _service.AddProductTag(pt);
        public List<Tag> GetAllTags() => _service.GetAllTags();
    }
}

