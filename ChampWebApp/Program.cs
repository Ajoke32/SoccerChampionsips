using ChampWebApp;
using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.GraphQl.Queries;
using ChampWebApp.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

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



builder.Services.AddDbContext<ChampoinoshipsContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UserQuery>();

builder.Services.AddGraphQLServer()
    .AddQueryType<UserQuery>()
    .AddFiltering()
    .ModifyRequestOptions(opt=>opt.IncludeExceptionDetails=true);

builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();

builder.Services.AddScoped<IUnitOfWorkRepository,UnitOfWorkRepository>();

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

app.MapGraphQL();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
