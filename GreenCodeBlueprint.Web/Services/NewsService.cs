using Examine;
using GreenCodeBlueprint.Web.Interfaces;
using GreenCodeBlueprint.Web.Models.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.Examine;

namespace GreenCodeBlueprint.Web.Services
{
    public class NewsService : INewsService
    {
        private readonly IExamineManager _examineManager;
        private readonly IPublishedContentQuery _publishedContentQuery;

        public NewsService(
            IExamineManager examineManager,
            IPublishedContentQuery publishedContentQuery)
        {
            _examineManager = examineManager;
            _publishedContentQuery = publishedContentQuery;
        }

        public IEnumerable<NewsItem> GetNewsItems()
        {
            if (!_examineManager.TryGetIndex(Constants.UmbracoIndexes.ExternalIndexName, out IIndex index))
            {
                throw new InvalidOperationException($"No searcher found with name {Constants.UmbracoIndexes.ExternalIndexName}");
            }

            var query = index.Searcher.CreateQuery(IndexTypes.Content);
            var filter = query.Field("__NodeTypeAlias", NewsItem.ModelTypeAlias);

            var results = filter.Execute();

            List<NewsItem> typedResults = new();

            foreach (var result in results)
            {
                var node = _publishedContentQuery.Content(result.Id);
                var typedNode = node as NewsItem;

                if (typedNode != null)
                {
                    typedResults.Add(typedNode);
                }
            }

            return typedResults;
        }
    }
}
