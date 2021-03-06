using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        DomainContext domainContext = new DomainContext();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = domainContext.Set<T>();
        }

        public void Delete(T t)
        {
            var deletedEntity = domainContext.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            domainContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T t)
        {
            var addedEntity = domainContext.Entry(t);
            addedEntity.State = EntityState.Added;
            domainContext.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            var uptatedEntity = domainContext.Entry(t);
            uptatedEntity.State = EntityState.Modified;
            domainContext.SaveChanges();
        }
    }
}
