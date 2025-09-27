using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.BannerDtos;
using Villa.Dto.Dtos.QuestDtos;
using Villa.Entity.Entities;

namespace Villa.Web.UI.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;

        public BannerController(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values=await _bannerService.TGetListAsync();
            var bannerList = _mapper.Map<List<ResultBannerDto>>(values);
            return View(bannerList);
        }
        public async Task<IActionResult> DeleteBanner(ObjectId id)
        {
            await _bannerService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            ModelState.Clear();
            var newBanner = _mapper.Map<Banner>(createBannerDto);
            var validator = new BannerValidator();
            var result = validator.Validate(newBanner);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _bannerService.TCreateAsync(newBanner);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult>UpdateBanner(ObjectId id)
        {
            var value=await _bannerService.TGetByIdAsync(id);
            var updateBanner=_mapper.Map<UpdateBannerDto> (value);
            return View(updateBanner);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            ModelState.Clear();
            var banner=_mapper.Map<Banner>(updateBannerDto);
            var validator = new BannerValidator();
            var result= validator.Validate(banner);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _bannerService.TUpdateAsync(banner);
            return RedirectToAction("Index");
        }
    }
}
