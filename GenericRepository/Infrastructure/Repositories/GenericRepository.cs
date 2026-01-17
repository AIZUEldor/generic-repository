using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Domain.Contracts;
using GenericRepository.Domain.Entities;

namespace GenericRepository.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity , new()
    {
        private readonly List<T> _data = new List<T>();
        private int _nextId = 1;

        public T Add(T entitiy)
        {
            entitiy.Id = _nextId++;
            _data.Add(entitiy);
            return entitiy;
        }
        public bool Update(T entity)
        {
            var old = _data.FirstOrDefault(x => x.Id == entity.Id);
            if (old == null) return false;
            
            int index = _data.IndexOf(old);
            _data[index] = entity;
            return true;
        }
        public bool Delete(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            if (item == null) return false;
            _data.Remove(item);
            return true;
        }
        public T? GetById(int id)
        {
            return _data.FirstOrDefault(x => x.Id == id);
        }
        public List<T> GetAll()
        {
            return _data.ToList();
        }
    }
}
