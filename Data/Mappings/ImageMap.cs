using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings;

public class ImageMap : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasData(new Image
        {
            Id = Guid.Parse("35AC5F88-8C37-4136-8067-3906E39D8B51"),
            FileName = "images/testimage",
            FileType = "jpg",
            CreatedBy = "Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new Image
        {
            Id = Guid.Parse("EBAEBC76-3FFB-47E7-A424-C4D0F3313EC5"),
            FileName = "images/vstest",
            FileType = "png",
            CreatedBy = "Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        }

        );
    }
}
