using Microsoft.AspNetCore.Mvc;
using SQLDemo.Models;
using SQLDemo.Repositories.CategoryRepo;
using SQLDemo.Repositories.ProductRepo;

namespace SQLDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetProduct().ToList();    
            return View(products);
        }
        public IActionResult Details(int? id)
        {
            var product = _productRepository.GetProductWithId(id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Category = _categoryRepository.GetCategories().ToList();
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProduct product)
        {
            ViewBag.Category = _categoryRepository.GetCategories().ToList();
            if (ModelState.IsValid)
            {
                _productRepository.CreateProduct(product);
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

            _productRepository.DeleteProduct(id);
            return View();
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
                ViewBag.Category = _categoryRepository.GetCategories().ToList();
                ProductVm product = _productRepository.GetProductWithIdEdit(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            return View();
        }


        [HttpPost]
        public IActionResult Edit(ProductVm product)
        {
            if (product == null)
                return BadRequest();
            ViewBag.Category = _categoryRepository.GetCategories().ToList();
            if (ModelState.IsValid)
            {
                _productRepository.EditProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
