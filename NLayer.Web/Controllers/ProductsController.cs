using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService services, ICategoryService categoryService, IMapper mapper)
        {
            _productService = services;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> ProductIndex()
        {
            var x = await _productService.GetProductsWithCategory();
            return View(x);
        }

        public async Task<IActionResult> Save()
        {
            var categories =await _categoryService.GetAllAsync();
            var categoriesDto=_mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
       
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(_mapper.Map<Product>(productDto));

                return RedirectToAction(nameof(ProductIndex));
            }
            var categories =await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }


    }
}
