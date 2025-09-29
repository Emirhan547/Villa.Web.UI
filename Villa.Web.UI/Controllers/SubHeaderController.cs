using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.DealDtos;
using Villa.Dto.Dtos.SubHeaderDtos;
using Villa.Entity.Entities;

namespace Villa.Web.UI.Controllers
{
    public class SubHeaderController : Controller
    {
        private readonly ISubHeaderService _subHeaderService;
        private readonly IMapper _mapper;

        public SubHeaderController(ISubHeaderService subHeaderService, IMapper mapper)
        {
            _subHeaderService = subHeaderService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _subHeaderService.TGetListAsync();
            var subHeaderList = _mapper.Map<List<ResultSubHeaderDto>>(values);
            return View(subHeaderList);
        }
        public async Task<IActionResult> DeleteSubHeader(ObjectId id)
        {
            await _subHeaderService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateSubHeader()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubHeader(CreateSubHeaderDto createSubHeaderDto)
        {
            ModelState.Clear();
            var newSubHeader = _mapper.Map<SubHeader>(createSubHeaderDto);
            var validator = new SubHeaderValidator();
            var result = validator.Validate(newSubHeader);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _subHeaderService.TCreateAsync(newSubHeader);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> UpdateSubHeader(ObjectId id)
        {
            var value = await _subHeaderService.TGetByIdAsync(id);
            var updateSubHeader = _mapper.Map<UpdateSubHeaderDto>(value);
            return View(updateSubHeader);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSubHeader(UpdateSubHeaderDto updateSubHeaderDto)
        {
            ModelState.Clear();
            var subHeader = _mapper.Map<SubHeader>(updateSubHeaderDto);
            var validator = new SubHeaderValidator();
            var result = validator.Validate(subHeader);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _subHeaderService.TUpdateAsync(subHeader);
            return RedirectToAction("Index");
        }
    }
}
