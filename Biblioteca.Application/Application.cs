using Biblioteca.Abstactions;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application
{
    public interface IApplication<T> : IDbOperation<T>
    {
    }
    public class Application<T> : IApplication<T>
    {
        private IRepository<T> _repositorio;
        public Application(IRepository<T> repositorio)
        {
            _repositorio = repositorio;
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
