using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Repositories
{
    public interface IRepository<T> where T : TEntity
    {
        void Create(T entity);
        T Get(Guid id);
        T[] GetAll();
        void Update(T entity);
        void Delete(Guid id);
    }
}