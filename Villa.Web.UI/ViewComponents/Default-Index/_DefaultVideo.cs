using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.VideoDtos;

namespace Villa.Web.UI.ViewComponents
{
    public class _DefaultVideo:ViewComponent
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public _DefaultVideo(IVideoService videoService, IMapper mapper)
        {
            _videoService = videoService;
            _mapper = mapper;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var video = await _videoService.TGetListAsync();
            var videoList = _mapper.Map<List<ResultVideoDto>>(video);

            return View(videoList);
        }
    }
}
