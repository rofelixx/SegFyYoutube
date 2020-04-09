using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SegFyYoutube.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegFyYoutube.Infra.Mapping
{
    public class YoutubeMap : IEntityTypeConfiguration<YouTube>
    {
        public void Configure(EntityTypeBuilder<YouTube> builder)
        {
            builder.ToTable("YouTube");

            builder.HasKey(c => c.Id);

            builder.Property(p => p.Description).IsRequired();

            builder.Property(p => p.Title).IsRequired();

            builder.Property(p => p.Type).IsRequired();

            builder.Property(p => p.SearchedAt).IsRequired();

        }
    }
}
