using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {

        DomainContext categoryContext = new DomainContext();
        DbSet<Category> _domainContext;

        public void Delete(Category c)
        {
            _domainContext.Remove(c);
            categoryContext.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category c)
        {
            _domainContext.Add(c);
            categoryContext.SaveChanges();
            
        }

        public List<Category> List()
        {
            return _domainContext.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category c)
        {
            categoryContext.SaveChanges();
        }
    }
}
