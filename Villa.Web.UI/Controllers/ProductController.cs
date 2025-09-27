using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.DealDtos;
using Villa.Dto.Dtos.FeatureDtos;
using Villa.Dto.Dtos.ProductDtos;
using Villa.Entity.Entities;

namespace Villa.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.TGetListAsync();
            var productList = _mapper.Map<List<ResultProductDto>>(values);
            return View(productList);
        }
        public async Task<IActionResult> DeleteProduct(ObjectId id)
        {
            await _productService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            ModelState.Clear();
            var newProduct = _mapper.Map<Product>(createProductDto);
            var validator = new ProductValidator();
            var result = validator.Validate(newProduct);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _productService.TCreateAsync(newProduct);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> UpdateProduct(ObjectId id)
        {
            var value = await _productService.TGetByIdAsync(id);
            var updateProduct = _mapper.Map<UpdateProductDto>(value);
            return View(updateProduct);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            ModelState.Clear();
            var product = _mapper.Map<Product>(updateProductDto);
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _productService.TUpdateAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ProductDetails(ObjectId id)
        {
            var value = await _productService.TGetByIdAsync(id);
            var detailProduct = _mapper.Map<ResultProductDto>(value);
            return View(detailProduct);
        }
    }
}