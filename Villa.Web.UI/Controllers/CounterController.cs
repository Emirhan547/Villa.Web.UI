 using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.BannerDtos;
using Villa.Dto.Dtos.ContactDtos;
using Villa.Dto.Dtos.CounterDtos;
using Villa.Entity.Entities;

namespace Villa.Web.UI.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterService _counterService;
        private readonly IMapper _mapper;

        public CounterController(ICounterService counterService, IMapper mapper)
        {
            _counterService = counterService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _counterService.TGetListAsync();
            var counterList = _mapper.Map<List<ResultCounterDto>>(values);
            return View(counterList);
        }
        public async Task<IActionResult> DeleteCounter(ObjectId id)
        {
            await _counterService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateCounter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCounter(CreateCounterDto createCounterDto)
        {
            ModelState.Clear();
            var newCounter = _mapper.Map<Counter>(createCounterDto);
            var validator = new CounterValidator();
            var result = validator.Validate(newCounter);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _counterService.TCreateAsync(newCounter);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> UpdateCounter(ObjectId id)
        {
            var value = await _counterService.TGetByIdAsync(id);
            var updateCounter = _mapper.Map<UpdateCounterDto>(value);
            return View(updateCounter);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCounter(UpdateCounterDto updateCounterDto)
        {
            ModelState.Clear();
            var counter = _mapper.Map<Counter>(updateCounterDto);
            var validator = new CounterValidator();
            var result = validator.Validate(counter);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _counterService.TUpdateAsync(counter);
            return RedirectToAction("Index");
        }
    }
}
