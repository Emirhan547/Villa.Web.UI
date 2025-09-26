using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core.Operations;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.DealDtos;
using Villa.Dto.Dtos.QuestDtos;
using Villa.Entity.Entities;

namespace Villa.Web.UI.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestService _questService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestService questService, IMapper mapper)
        {
            _questService = questService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _questService.TGetListAsync();
            var questionList = _mapper.Map<List<ResultQuestDto>>(values);
            return View(questionList);
        }
        public async Task<IActionResult> DeleteQuestion(ObjectId id)
        {
            await _questService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestDto createQuestDto)
        {ModelState.Clear();
            var newQuestion = _mapper.Map<Quest>(createQuestDto);
            var validator=new QuestionValidator();
            var result=validator.Validate(newQuestion);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                 {
                     ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                 });
                return View();
            }
            await _questService.TCreateAsync(newQuestion);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> UpdateQuestion(ObjectId id)
        {
            var value = await _questService.TGetByIdAsync(id);
            var updateQuestion = _mapper.Map<UpdateQuestDto>(value);
            return View(updateQuestion);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestDto updateQuestDto)
        {
            var updateQuestion = _mapper.Map<Quest>(updateQuestDto);
            await _questService.TUpdateAsync(updateQuestion);
            return RedirectToAction("Index");
        }
    }
}
