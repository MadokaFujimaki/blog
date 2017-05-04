using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using PizzeriaEpiserverSite.Business;
using PizzeriaEpiserverSite.Models.Pages;
using PizzeriaEpiserverSite.Models.ViewModels;

namespace PizzeriaEpiserverSite.Controllers
{
    public class BlogCategoryListPageController : PageController<BlogCategoryListPage>
    {
        //public ActionResult Index(BlogCategoryListPage currentPage)
        //{
        //    var model = new BlogCategoryListViewModel(currentPage)
        //    {
        //        Categories = GetAllCategories(),
        //    };
        //    return View(model);
        //}

        public ActionResult Index(BlogCategoryListPage currentPage, string category)
        {
            if (category != null)
            {
                var model = new BlogCategoryListViewModel(currentPage)
                {
                    Categories = GetAllCategories(),
                    Pages = FindPagesForCategory(category)
                };
                return View(model);
            }
            else
            {
                var model = new BlogCategoryListViewModel(currentPage)
                {
                    Categories = GetAllCategories(),
                };
                return View(model);
            }
        }

        private List<BlogPage> FindPagesForCategory(string category)
        {
            var pageTypeId = ServiceLocator.Current.GetInstance<IContentTypeRepository>()
                .Load<BlogPage>()
                .ID;

            var criteria = new PropertyCriteria
            {
                Condition = CompareCondition.Equal,
                Name = "PageTypeID",
                Type = PropertyDataType.PageType,
                Value = pageTypeId.ToString(),
                Required = true
            };

            PropertyCriteria categoryCriteria = new PropertyCriteria();
            categoryCriteria.Name = "PageCategory";
            categoryCriteria.Type = PropertyDataType.Category;
            categoryCriteria.Condition = CompareCondition.Equal;
            categoryCriteria.Value = category; 

            var criterias = new PropertyCriteriaCollection
            {
                criteria,
                categoryCriteria
            };

            var criteriaQueryService = ServiceLocator.Current.GetInstance<IPageCriteriaQueryService>();
            var pages = criteriaQueryService.FindPagesWithCriteria(PageReference.StartPage, criterias);

            return pages.Cast<BlogPage>().ToList();
            //return new List<BlogPage>();
        }

        private List<Category> GetAllCategories()
        {
            var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
            var root = categoryRepository.GetRoot();
            var children = root.Categories;
            return children.Select(x => x).ToList();
        }
    }
}