using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasData(new Article
        {
            Id=Guid.NewGuid(),
            Title="Asp .Net Core Deneme Makalesi 1",
            Content= "ASP.NET Core, modern, bulut özellikli, İnternet'e bağlı uygulamalar oluşturmaya yönelik platformlar arası, yüksek performanslı , açık kaynak bir çerçevedir.",
            ViewCount=15,                                 
            CategoryId= Guid.Parse("85C232EB-493A-4A7F-825E-30C01025BC59"),
            ImageId= Guid.Parse("35AC5F88-8C37-4136-8067-3906E39D8B51"),
            CreatedBy = "Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = Guid.Parse("002CAE81-05C5-4534-82B9-F339BCA8E5B3"),

        },
        new Article
        {
            Id = Guid.NewGuid(),
            Title = "Visual Studio Deneme Makalesi 1",
            Content = "Visual Studio, geliştirme döngüsünün tamamını tek bir yerde tamamlamak için kullanabileceğiniz güçlü bir geliştirici aracıdır. Kod yazmak, düzenlemek, hata ayıklamak ve derlemek için kullanabileceğiniz kapsamlı bir tümleşik geliştirme ortamıdır (IDE). ",
            ViewCount = 10,          
            ImageId= Guid.Parse("EBAEBC76-3FFB-47E7-A424-C4D0F3313EC5"),
            CategoryId = Guid.Parse("9EAD3CB0-5E4C-431C-8E50-DC02BFC77161"),
            CreatedBy = "Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = Guid.Parse("1F51BBD1-312C-44FE-98EA-203E1C17EE5A"),
        }
        );      
    }
}
