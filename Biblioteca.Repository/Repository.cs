using Biblioteca.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Repository
{
    public interface IRepository<T> : IDbOperation<T>
    {
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        IDbContext<T> _db;
        public Repository(IDbContext<T> db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
