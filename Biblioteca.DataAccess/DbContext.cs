using Biblioteca.Abstactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DataAccess
{
    public class DbContext<T> : IDbOperation<T> where T : class
    {
        DbSet<T> _Items;
        DbDataAccess _ctx;
        public DbContext(DbDataAccess ctx)
        {
            _ctx = ctx;
            _Items = _ctx.Set<T>();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            return _Items.ToList();
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
