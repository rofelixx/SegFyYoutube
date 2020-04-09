using SegFyYoutube.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegFyYoutube.Domain.Interfaces
{
    public interface IYoutubeRepository : IBaseRepository<YouTube>
    {
        YouTube GetByDescription(string email);
        void SaveRange(List<YouTube> obj);
        List<YouTube> GetAllByIds(List<string> idList);
    }
}
