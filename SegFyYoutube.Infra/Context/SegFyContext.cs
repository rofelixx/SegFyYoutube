using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SegFyYoutube.Domain.Entities;
using SegFyYoutube.Infra.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SegFyYoutube.Infra.Context
{
    public class SegFyContext : DbContext
    {
        public SegFyContext(DbContextOptions<SegFyContext> options) : base(options) { }

        public DbSet<YouTube> Youtube { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new YoutubeMap());

        }
    }
}
