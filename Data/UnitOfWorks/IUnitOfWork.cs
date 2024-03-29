﻿using Core.Entities;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();

    Task<int> SaveAsync();
    int Save();
}
