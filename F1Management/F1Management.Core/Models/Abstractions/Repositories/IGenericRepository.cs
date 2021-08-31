using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface IGenericRepository<T>
    {
        public List<T> GetAll();
        public T GetById(Guid id);
        public void Add(T item);
        public void Update(T item);
        public void Delete(T item);
    }
}
