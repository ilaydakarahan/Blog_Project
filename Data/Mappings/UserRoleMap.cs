using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings;

public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.HasKey(r => new { r.UserId, r.RoleId });

        // Maps to the AspNetUserRoles table
        builder.ToTable("AspNetUserRoles");

        builder.HasData(new AppUserRole
        {
            UserId = Guid.Parse("002CAE81-05C5-4534-82B9-F339BCA8E5B3"),
            RoleId = Guid.Parse("98222420-FFC2-46E3-97B7-D78F68843102")
        },
        new AppUserRole
        {
            UserId = Guid.Parse("1F51BBD1-312C-44FE-98EA-203E1C17EE5A"),
            RoleId = Guid.Parse("F71F1327-469C-41A4-AD38-58C89C47D198")

        });        
    }
}
