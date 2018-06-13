using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : TEntity
    {
        private static List<T> dadosBD = new List<T>();

        public void Create(T entity)
        {
            dadosBD.Add(entity);
        }

        public void Delete(Guid id)
        {
            T entidadeOriginal = dadosBD.Find(n => n.Id == id);
            dadosBD.Remove(entidadeOriginal);
        }

        public T[] GetAll()
        {
            return dadosBD.ToArray();
        }

        public T Get(Guid id)
        {
            return dadosBD.Find(n => n.Id == id);
        }

        public void Update(T entity)
        {
            Delete(entity.Id);
            Create(entity);
        }
    }
}
