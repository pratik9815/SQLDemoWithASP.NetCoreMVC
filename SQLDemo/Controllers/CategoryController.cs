using Microsoft.AspNetCore.Mvc;
using SQLDemo.Models;
using SQLDemo.Repositories.CategoryRepo;

namespace SQLDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetCategories().ToList();
            return View(categories);
        }
        [HttpGet]
       public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Create(CreateCategory category)
        {
            if(ModelState.IsValid)
            {
                _categoryRepository.CreateCategory(category);
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CategoryVm category = _categoryRepository.GetCategoryWithId(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                CategoryVm category = _categoryRepository.GetCategoryWithId(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
            return View();
        }


        [HttpPost]
        public IActionResult Edit(CategoryVm category)
        {
            if (category == null)
                return BadRequest();
            if(ModelState.IsValid)
            {
                _categoryRepository.EditCategory(category);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _categoryRepository.DeleteCategory(id);
            return View();
        }
    }

}
