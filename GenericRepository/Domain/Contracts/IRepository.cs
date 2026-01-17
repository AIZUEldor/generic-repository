using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Domain.Entities;

namespace GenericRepository.Domain.Contracts
{
    public interface  IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        T? GetById(int id);
        List<T> GetAll();
    }
}
