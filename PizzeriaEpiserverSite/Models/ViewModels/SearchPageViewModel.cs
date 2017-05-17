using EPiServer.Globalization;
using EPiServer.Search;
using EPiServer.Search.Queries.Lucene;
using PizzeriaEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using Lucene.Net.Support;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class SearchPageViewModel : IPageViewModel<SearchPage>
    {
        public SearchPage CurrentPage { get; set; }
        public string SearchText { get; set; }
        //public List<IndexResponseItem> SearchResult { get; set; }
        public List<PageDataCollection> SearchResult { get; set; }

        public SearchPageViewModel(SearchPage currentPage)
        {
            CurrentPage = currentPage;
        }


        public void Search(string q)
        {
            //var culture = ContentLanguage.PreferredCulture.Name;
            //SearchResult = new List<IndexResponseItem>();
            //var fieldQuery = new FieldQuery(q);

            //var fieldQueryResult = SearchHandler.Instance.GetSearchResults(fieldQuery, 1, 40)
            //    .IndexResponseItems
            //    .Where(x => (x.Culture.Equals(culture) || string.IsNullOrEmpty(x.Culture)))
            //    .ToList();

            //SearchResult.AddRange(fieldQueryResult);



            var culture = ContentLanguage.PreferredCulture.Name;
            SearchResult = new List<PageDataCollection>();
            var fieldQuery = new FieldQuery(q);

            var fieldQueryResult = SearchHandler.Instance.GetSearchResults(fieldQuery, 1, 40)
                .IndexResponseItems
                .Where(x => (x.Culture.Equals(culture) || string.IsNullOrEmpty(x.Culture)))
                .ToList();

            SearchResult.AddRange(fieldQueryResult.Cast<PageDataCollection>());


            //var searchResults = SearchResult.Select(x => x);
            PageDataCollection searchResultList = new PageDataCollection();

            foreach (var searchResult in SearchResult)
            {
                //FilterForVisitor.Filter(searchResult);
                searchResultList.Add(FilterForVisitor.Filter(searchResult).Cast<PageDataCollection>());
            }

            var result = searchResultList.Select(x => x).Cast<SearchPageViewModel>();

        }
    }
}