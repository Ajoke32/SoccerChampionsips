using AutoMapper;
using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ChampWebApp.Controllers;

public class ChampController:Controller
{
    private readonly IMapper _mapper;
	
    private readonly IUnitOfWorkRepository _repos;

    public ChampController(IMapper mapper,IUnitOfWorkRepository repos)
    {
        _mapper = mapper;
        _repos = repos;
    }
    
    [HttpGet]
    [Authorize("Create")]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(string name)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        await _repos.GenericRepository<Tournament>().CreateAsync(new Tournament()
        {
            Name = name
        });
        
        return RedirectToAction("Create");
    }

    public async Task<IActionResult> Info(int id)
    {
        var tournament = await _repos.GenericRepository<Tournament>()
            .FindAsync(t=>t.Id==id,relatedData:"LeagueSummaries.Command");
        
        return View(tournament);
    }
}

