using Vite.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();

builder.Services.AddViteServices(options =>
{
    options.Server.PackageDirectory = "../GreenCodeBlueprint.Frontend";
    options.Server.AutoRun = true;
    options.Server.Https = true;
});

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseHttpsRedirection();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

if (app.Environment.IsDevelopment())
{
  app.UseViteDevelopmentServer(true);
}

await app.RunAsync();
