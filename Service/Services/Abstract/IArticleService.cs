using Entity.Dtos.Articles;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Abstract;

public interface IArticleService
{
    Task<List<ArticleDto>> GetAllArticlesAsync();
}
