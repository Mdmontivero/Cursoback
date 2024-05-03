﻿using Cursoback.Model;

namespace Cursoback.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity>GetById(int id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();

        IEnumerable<TEntity> Search(Func<Beer, bool> filter);
    }
}