using SegFyYoutube.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegFyYoutube.Domain.Interfaces
{
    public interface IYoutubeService
    {
        void SaveRange(List<YouTube> listToSave);
        List<YouTube> GetAllByIds(List<string> idList);
    }
}
