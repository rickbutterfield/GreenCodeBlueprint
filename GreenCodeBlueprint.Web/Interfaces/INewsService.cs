using GreenCodeBlueprint.Web.Models.ModelsBuilder;

namespace GreenCodeBlueprint.Web.Interfaces
{
    public interface INewsService
    {
        public IEnumerable<NewsItem> GetNewsItems();
    }
}
