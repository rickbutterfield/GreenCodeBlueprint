using GreenCodeBlueprint.Web.Interfaces;
using GreenCodeBlueprint.Web.Models.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace GreenCodeBlueprint.Web.Services
{
    public class NewsService : INewsService
    {
        private readonly IPublishedContentQuery _publishedContentQuery;

        public NewsService(IPublishedContentQuery publishedContentQuery)
        {
            _publishedContentQuery = publishedContentQuery;
        }

        public IEnumerable<NewsItem> GetNewsItems(int skip = 0, int take = 10)
        {
            var root = _publishedContentQuery.ContentAtRoot().FirstOrDefault(x => x.IsDocumentType(Home.ModelTypeAlias));
            var newsRoot = root?.Children<News>()?.FirstOrDefault();
            var newsArticles = newsRoot?.Children<NewsItem>()?.Where(x => x.IsVisible());

            if (newsArticles != null)
            {
                return newsArticles.Skip(skip).Take(take).ToList();
            }

            return new List<NewsItem>();
        }        
    }
}
