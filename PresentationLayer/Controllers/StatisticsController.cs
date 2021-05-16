using DataAccessLayer.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics

        DomainContext domainContext = new DomainContext();

        public ActionResult Index()
        {

            var categoryCount = domainContext.Categories.Count();
            ViewBag.categoryCount = categoryCount;
            var softwareCount = domainContext.Headings.Count(h => h.Category.CategoryName == "Yazılım");
            ViewBag.softwareCount = softwareCount;
            var aContainsNameCount = domainContext.Writers.Count(w => w.WriterName.Contains("a"));
            ViewBag.aContainsNameCount = aContainsNameCount;
            var maxHeadingCategoryName = domainContext.Headings.Where(h => h.CategoryID == (domainContext.Headings.GroupBy(g => g.CategoryID).OrderByDescending(o => o.Count()).Select(s => s.Key).FirstOrDefault())).Select(s => s.Category.CategoryName).FirstOrDefault();
            ViewBag.maxHeadingCategoryName = maxHeadingCategoryName;
            var statusTrue = domainContext.Categories.Count(c => c.CategoryStatus == true);
            var statusFalse = domainContext.Categories.Count(c => c.CategoryStatus == false);
            var statusResult = (statusTrue - statusFalse);
            ViewBag.statusResult = statusResult;

            return View();
        }
    }
}