using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class AdminCategoryController : Controller
    {

        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = categoryManager.GetByID(id);
            categoryManager.Delete(categoryValue);
            return RedirectToAction("Index");
        }

        
        public ActionResult UpdateCategory(int id)
        {
            var categoryValue = categoryManager.GetByID(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }


    }
}