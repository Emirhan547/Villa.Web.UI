using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.FeatureDtos;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Entity.Entities;

namespace Villa.Web.UI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _messageService.TGetListAsync();
            var valueList = _mapper.Map<List<ResultMessageDto>>(values);
            return View(valueList);
        }
        public async Task<IActionResult> DeleteMessage(ObjectId id)
        {
            await _messageService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            ModelState.Clear();
            var newMessage = _mapper.Map<Message>(createMessageDto);
            var validator = new MessageValidator();
            var result = validator.Validate(newMessage);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _messageService.TCreateAsync(newMessage);
            return RedirectToAction("Index");

        }
    }
}
