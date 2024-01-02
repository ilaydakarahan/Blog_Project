using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new Category
        {
            Id = Guid.Parse("85C232EB-493A-4A7F-825E-30C01025BC59"),
            Name = "ASP .NET Core",
            CreatedBy = "Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new Category
        {
            Id = Guid.Parse("9EAD3CB0-5E4C-431C-8E50-DC02BFC77161"),
            Name = "Visual Studio 2022",
            CreatedBy = "Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        }       
        );        
    }
}
