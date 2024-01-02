using AutoMapper;
using Data.UnitOfWorks;
using Entity.Dtos.Articles;
using Entity.Entities;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete;

public class ArticleService : IArticleService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<List<ArticleDto>> GetAllArticlesAsync()
    {
        var articles = await unitOfWork.GetRepository<Article>().GetAllAsync();
        var map = mapper.Map<List<ArticleDto>>(articles);
        return map;
    }
}
