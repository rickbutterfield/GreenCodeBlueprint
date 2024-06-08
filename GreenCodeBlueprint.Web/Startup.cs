using GreenCodeBlueprint.Web.Interfaces;
using GreenCodeBlueprint.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace GreenCodeBlueprint.Web
{
    public class Startup : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<INewsService, NewsService>();
        }
    }
}