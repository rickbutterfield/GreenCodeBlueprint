using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;
using Google.Apis.Oauth2.v2;
using GreenCodeBlueprint.Web.Options;

namespace GreenCodeBlueprint.Web.Extensions
{
    public static class GoogleAuthenticationExtensions
    {
        public static IUmbracoBuilder AddGoogleAuthentication(this IUmbracoBuilder builder)
        {
            builder.AddBackOfficeExternalLogins(logins =>
            {
                logins.AddBackOfficeLogin(
                    backOfficeAuthenticationBuilder =>
                    {
                        // The scheme must be set with this method to work for the back office
                        var schemeName =
                              backOfficeAuthenticationBuilder.SchemeForBackOffice(GoogleBackOfficeExternalLoginProviderOptions
                                  .SchemeName);

                        ArgumentNullException.ThrowIfNull(schemeName);

                        backOfficeAuthenticationBuilder.AddGoogle(
                          schemeName,
                          "minim studio",
                          options =>
                          {
                              options.AccessType = "offline";
                              options.CallbackPath = "/umbraco-google-signin";
                              options.ClientId = "552469615141-3oluervbd5an3pul3skuj8kan099ft4l.apps.googleusercontent.com";
                              options.ClientSecret = "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";

                              options.Scope.Add(Oauth2Service.Scope.UserinfoEmail);
                              options.Scope.Add(Oauth2Service.Scope.UserinfoProfile);
                              options.Scope.Add(Oauth2Service.Scope.Openid);

                              options.Events.OnRedirectToAuthorizationEndpoint = evt =>
                              {
                                  evt.RedirectUri += "&hd=minim.studio";
                                  evt.Response.Redirect(evt.RedirectUri);
                                  return Task.FromResult(0);
                              };
                          });
                    });
            });

            return builder;
        }

    }
}