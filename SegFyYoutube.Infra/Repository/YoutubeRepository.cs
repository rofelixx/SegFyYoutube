using Microsoft.EntityFrameworkCore;
using SegFyYoutube.Domain.Entities;
using SegFyYoutube.Domain.Interfaces;
using SegFyYoutube.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegFyYoutube.Infra.Repository
{
    public class YoutubeRepository : BaseRepository<YouTube>, IYoutubeRepository
    {
        public YoutubeRepository(SegFyContext context)
            : base(context)
        {

        }

        public YouTube GetByDescription(string desc)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Description.Contains(desc));
        }

        public void SaveRange(List<YouTube> obj)
        {
            foreach (var item in obj)
            {
                AddOrUpdate(item);
            }
        }

        public List<YouTube> GetAllByIds(List<string> idList)
        {
            return DbSet.AsNoTracking().Where(w => idList.Contains(w.Id)).ToList();
        }
    }
}
