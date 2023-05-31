using System.Diagnostics;
using AutoMapper;
using ChampWebApp.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
using ChampWebApp.Models;
using ChampWebApp.Models.Dtos.Display;
using Microsoft.AspNetCore.Authorization;

namespace ChampWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IMapper _mapper;
    
    private readonly IUnitOfWorkRepository _repos;
    public HomeController(ILogger<HomeController> logger,IUnitOfWorkRepository uof,IMapper mapper)
    {
        _repos = uof;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<IActionResult> Index()
    {
        var users = await _repos.GenericRepository<User>().GetAsync(includeProperties:"Role");
        
        return View(_mapper.Map<IEnumerable<User>,IEnumerable<UserDisplayDto>>(users));
    }
    
    
    public IActionResult Register(User user)
    {
        
        return Redirect("Index");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
