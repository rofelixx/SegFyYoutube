using SegFyYoutube.Domain.Enum;
using System;

namespace SegFyYoutube.Domain.Entities
{
    public class YouTube : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EYoutubeType Type { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}
