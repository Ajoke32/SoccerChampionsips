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
    
    
    public async Task<IActionResult> Command()
    {
        var players = await _repos.GenericRepository<GameMatch>()
            .GetAsync(includeProperties:"HomeCommand,VisitCommand," +
                                        "MatchEvents,MatchEvents.Player," +
                                        "MatchEvents.Player.Command,MatchStatistics,MatchStatistics.Command");
        
        return View(players);
    }
    

    public async Task<IActionResult> Summary(int id)
    {
        var tournament = await _repos.GenericRepository<Tournament>().FindAsync(e=>e.Id==id);
        if (tournament != null)
        {
            ViewBag.LeagueName = tournament.Name; 
        }
        
        var summary = await _repos.GenericRepository<LeagueSummary>()
            .GetAsync(filter:(l=>l.Tournament.Id==id),
                includeProperties:"Command");
        

        return View(summary);
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
