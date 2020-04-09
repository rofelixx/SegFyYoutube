using SegFyYoutube.Application.DTO;
using SegFyYoutube.Domain.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegFyYoutube.Application.Interfaces
{
    public interface IYoutubeAppService
    {
        Task<List<YoutubeDto>> Pesquisar(string descricao, EYoutubeType searchType);
    }
}
