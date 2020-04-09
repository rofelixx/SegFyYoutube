using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SegFyYoutube.Application.Services;
using SegFyYoutube.Domain.Entities;
using SegFyYoutube.Domain.Interfaces;
using SegFyYoutube.Infra.Context;
using SegFyYoutube.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SegFyYoutube.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Teste_GetAllByIds()
        {
            var listVideos = new List<YouTube>();
            // YoutubeEntity
            listVideos.Add(new YouTube()
            {
                Id = "a9__D53WsUs",
                Description = "Amazon Web Services (AWS) is the world’s most comprehensive and broadly adopted cloud platform, offering over 175 services such as compute, databases, and storage. Learn more: https://amzn.to/33lsybW",
                Title = "What is AWS?",
                SearchedAt = DateTime.Now,
                Type = Domain.Enum.EYoutubeType.Video
            });

            var options = new DbContextOptionsBuilder<SegFyContext>().UseInMemoryDatabase().Options;

            var context = new SegFyContext(options);

            context.AddRange(listVideos);
            context.SaveChanges();

            var repository = new YoutubeRepository(context);

            var listIds = new List<string>() { "a9__D53WsUs" };

            var items = repository.GetAllByIds(listIds);

            // Assert
            Assert.IsTrue(items.Any());
        }

        [TestMethod]
        public void Teste_AddOrUpdate()
        {
            // YoutubeEntity
            var video = new YouTube()
            {
                Id = "a9__D53WsUs",
                Description = "Amazon Web Services (AWS) is the world’s most comprehensive and broadly adopted cloud platform, offering over 175 services such as compute, databases, and storage. Learn more: https://amzn.to/33lsybW",
                Title = "What is AWS?",
                SearchedAt = DateTime.Now,
                Type = Domain.Enum.EYoutubeType.Video
            };

            var options = new DbContextOptionsBuilder<SegFyContext>().UseInMemoryDatabase().Options;

            var context = new SegFyContext(options);

            var repository = new YoutubeRepository(context);

            repository.AddOrUpdate(video);

            video.Type = Domain.Enum.EYoutubeType.Canal;

            repository.AddOrUpdate(video);

            var listIds = new List<string>() { "a9__D53WsUs" };

            var items = repository.GetAllByIds(listIds);

            // Assert
            Assert.AreEqual(1, items.Count());
        }

    }
}
