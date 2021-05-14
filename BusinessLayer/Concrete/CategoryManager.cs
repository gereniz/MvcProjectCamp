﻿using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repository = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
            return repository.List();
        }

        public void Add(Category c)
        {
            if(c.CategoryName == "" || c.CategoryName.Length <=3 || c.CategoryDescription=="" || c.CategoryName.Length >= 51)
            {
                //hata mesajı
            }
            else
            {
                repository.Insert(c);
            }
        }
    }
}