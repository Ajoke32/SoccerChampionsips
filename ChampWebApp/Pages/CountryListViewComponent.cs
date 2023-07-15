using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChampWebApp.Pages;


public class CountryListViewComponent : ViewComponent
{
    private readonly IUnitOfWorkRepository _repos;
    
    public CountryListViewComponent(IUnitOfWorkRepository uow)
    {
        _repos = uow;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var countries = await _repos.GenericRepository<Country>().GetAsync();
        return View(countries);
    }
}