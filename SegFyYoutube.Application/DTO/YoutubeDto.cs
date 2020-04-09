using SegFyYoutube.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegFyYoutube.Application.DTO
{
    public class YoutubeDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EYoutubeType Type { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}
