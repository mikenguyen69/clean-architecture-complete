using CleanArchitectureV3.Core.SharedEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureV3.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> List();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
