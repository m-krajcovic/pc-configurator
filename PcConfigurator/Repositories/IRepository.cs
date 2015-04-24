﻿using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        T GetById(string id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(string id);
        IList<T> GetAll();
    }
}