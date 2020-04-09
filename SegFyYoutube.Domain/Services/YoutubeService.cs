using SegFyYoutube.Domain.Entities;
using SegFyYoutube.Domain.Enum;
using SegFyYoutube.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegFyYoutube.Application.Services
{
    public class YoutubeService : IYoutubeService
    {
        private readonly IYoutubeRepository _youtubeRepository;

        public YoutubeService(IYoutubeRepository youtubeRepository)
        {
            _youtubeRepository = youtubeRepository;
        }

        public void SaveRange(List<YouTube> listToSave)
        {
            _youtubeRepository.SaveRange(listToSave);
        }

        public List<YouTube> GetAllByIds(List<string> idList)
        {
            return _youtubeRepository.GetAllByIds(idList);
        }
    }
}
