using System.Text.Json.Serialization;
using AutoMapper;
using ChampWebApp;
using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Enums;
using ChampWebApp.GraphQl.Mutations;
using ChampWebApp.GraphQl.Queries;
using ChampWebApp.Repositories;
using ChampWebApp.Utils.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();





builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        options.AccessDeniedPath = "/Home/Index";
        options.LoginPath = "/User/Login";
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LoggedIn", (a) =>
    {
        a.RequireAuthenticatedUser();
    });
    
    options.AddPolicy("Read", p =>
    {
        p.Requirements.Add(new PermissionRequirement(Permissions.Read));
    });
    
    
    options.AddPolicy("AllRights", p =>
    {
        p.Requirements.Add(new PermissionRequirement(Permissions.Create|Permissions.Read
                                                                       |Permissions.Delete|Permissions.Update));
    });
    
    options.AddPolicy("Create", p =>
    {
        p.Requirements.Add(new PermissionRequirement(Permissions.Create));
    });
    
    options.AddPolicy("Delete", p =>
    {
        p.Requirements.Add(new PermissionRequirement(Permissions.Delete));
    });
    
});

builder.Services
    .AddCryptoClient()
    .ConfigureHttpClient(c =>
        c.BaseAddress = new Uri("http://localhost:5009/graphql"));

builder.Services.ConfigureHttpJsonOptions(o => o.SerializerOptions.MaxDepth=10000000);

builder.Services.AddDbContext<ChampoinoshipsContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();

builder.Services.AddScoped<IUnitOfWorkRepository,UnitOfWorkRepository>();

builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider
    .RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF5cXmtCdkx3Rnxbf1xzZFxMYFRbRXBPMyBoS35RdUVkWHteeXRcRmZUWUB1");

builder.Services.AddGraphQLServer()
    .AddQueryType<RootQuery>()
    .AddMutationType<RootMutation>()
    .AddFiltering()
    .AddSorting()
    .ModifyRequestOptions(opt=>opt.IncludeExceptionDetails=true);

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapGraphQL();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
