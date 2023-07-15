using AutoMapper;
using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;
using ChampWebApp.Models.Dtos.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChampWebApp.Controllers;

public class CommandController:Controller
{
	private readonly IMapper _mapper;
	
	private readonly IUnitOfWorkRepository _repos;
	
	public CommandController(IUnitOfWorkRepository uof,IMapper mapper)
	{
		_repos = uof;
		_mapper = mapper;
	}
	public async Task<IActionResult> Index()
	{
		var commands = await _repos.GenericRepository<Command>().GetAsync(includeProperties:"Coach,Country");
		
		
		
		return View(commands);
	}
	
	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}
	
	[HttpPost]
	public async Task<IActionResult> Create(CommandInputDto command)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}

		var model = _mapper.Map<Command>(command);
		await _repos.GenericRepository<Command>().CreateAsync(model);
		if (command.CoachId!=null)
		{
			var coaches = await _repos.GenericRepository<Coach>().GetAsync(filter: c => c.Id == command.CoachId);
			var coach = coaches.FirstOrDefault();
			if (coach != null){ model.Coach = coach;}
		}
		await _repos.SaveAsync();
		TempData["SuccessMessage"] = "Command created!";
		return RedirectToAction("Create");
	}
}