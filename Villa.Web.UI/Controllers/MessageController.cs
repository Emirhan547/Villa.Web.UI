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
       
        public async Task<IActionResult> MessageDetails(ObjectId id)
        {
            var value = await _messageService.TGetByIdAsync(id);
            var valueDto = _mapper.Map<ResultMessageDto>(value);
            return View(valueDto);
        }
    }
}