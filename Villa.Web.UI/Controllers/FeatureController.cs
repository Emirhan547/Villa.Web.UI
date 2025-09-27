using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.CounterDtos;
using Villa.Dto.Dtos.FeatureDtos;
using Villa.Entity.Entities;

namespace Villa.Web.UI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task <IActionResult> Index()
        {
            var values= await _featureService.TGetListAsync();
            var valueList=_mapper.Map<List<ResultFeatureDto>>(values);
            return View(valueList);
        }
        public async Task<IActionResult> DeleteFeature(ObjectId id)
        { 
            await _featureService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            ModelState.Clear();
            var newFeature = _mapper.Map<Feature>(createFeatureDto);
            var validator = new FeatureValidator();
            var result = validator.Validate(newFeature);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _featureService.TCreateAsync(newFeature);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> UpdateFeature(ObjectId id)
        {
            var value=await _featureService.TGetByIdAsync(id);
            var updateFeatureDto=_mapper.Map<UpdateFeatureDto>(value);
            return View(updateFeatureDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            ModelState.Clear();
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            var validator = new FeatureValidator();
            var result = validator.Validate(feature);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _featureService.TUpdateAsync(feature);
            return RedirectToAction("Index");
        }
    }
}
