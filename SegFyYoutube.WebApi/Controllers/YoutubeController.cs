using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SegFyYoutube.Application.DTO;
using SegFyYoutube.Application.Interfaces;
using SegFyYoutube.Domain.Enum;

namespace SegFyYoutube.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private readonly IYoutubeAppService _youtubeAppService;

        public YoutubeController(IYoutubeAppService youtubeAppService) : base()
        {
            _youtubeAppService = youtubeAppService;
        }

        [HttpGet]
        [Produces(typeof(List<YoutubeDto>))]
        public async Task<ActionResult> Get([FromQuery] string searchFilter, [FromQuery] EYoutubeType searchType)
        {
            if (string.IsNullOrEmpty(searchFilter))
                return new BadRequestResult();

            return Ok(await _youtubeAppService.Pesquisar(searchFilter, searchType));
        }
    }
}
