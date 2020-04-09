using AutoMapper;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using SegFyYoutube.Application.DTO;
using SegFyYoutube.Application.Interfaces;
using SegFyYoutube.Domain.Entities;
using SegFyYoutube.Domain.Enum;
using SegFyYoutube.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegFyYoutube.Application.Services
{
    public class YoutubeAppService : IYoutubeAppService
    {
        private readonly IYoutubeService _youtubeService;
        private readonly IMapper _mapper;


        public YoutubeAppService(IYoutubeService youtubeService, IMapper mapper)
        {
            _youtubeService = youtubeService;
            _mapper = mapper;
        }

        public async Task<List<YoutubeDto>> Pesquisar(string search, EYoutubeType searchType)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC1g_f4Jtoh144MoJZiZwF7_H-ajrgiaIw",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = search; // Replace with your search term.
            searchListRequest.MaxResults = 10;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<YoutubeDto> response = new List<YoutubeDto>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        response.Add(new YoutubeDto
                        {
                            Id = searchResult.Id.VideoId,
                            Title = searchResult.Snippet.Title,
                            Description = searchResult.Snippet.Description,
                            Type = EYoutubeType.Video,
                            PublishedAt = searchResult.Snippet.PublishedAt,
                            SearchedAt = System.DateTime.Now
                        });

                        break;

                    case "youtube#channel":
                        response.Add(new YoutubeDto
                        {
                            Id = searchResult.Id.ChannelId,
                            Title = searchResult.Snippet.ChannelTitle,
                            Description = searchResult.Snippet.Description,
                            Type = EYoutubeType.Canal,
                            PublishedAt = searchResult.Snippet.PublishedAt,
                            SearchedAt = System.DateTime.Now
                        });

                        break;
                }
            }

            var entityList = _mapper.Map<List<YouTube>>(response);

            //Save response to database
            _youtubeService.SaveRange(entityList);

            //Get data from database filtered by response ids
            var idList = entityList.Select(s => s.Id).ToList();

            var dataFiltered = _mapper.Map<List<YoutubeDto>>(_youtubeService.GetAllByIds(idList));

            return dataFiltered.Where(w => w.Type == searchType).ToList();
        }
    }
}
