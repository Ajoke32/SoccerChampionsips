using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;
using ChampWebApp.Models.Dtos;
using ChampWebApp.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChampWebApp.Controllers;

public class UserController:Controller
{
    private readonly IUnitOfWorkRepository _unitOfWork;
    
    private readonly IMapper _mapper;
    
    public UserController(IUnitOfWorkRepository repos,IMapper mapper)
    {
        _unitOfWork = repos;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDto user)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Login");
        }
        var searchUser = await _unitOfWork.GenericRepository<User>().FindAsync(u => u.Email == user.Email);

        if (searchUser == null) return View();
        
        var res = PasswordHelper.VerifyPassword(user.Password,
            Convert.FromBase64String(searchUser.PasswordHash),
            Convert.FromBase64String(searchUser.PasswordSalt));
        
        if (!res) { return View(); }

        var claims = new List<Claim>()
        {
            new Claim("Email",searchUser.Email),
            new Claim("RoleId",searchUser.RoleId.ToString()),
            new Claim("Name",searchUser.Name)
        };
        var claimsIdentity = new ClaimsIdentity(claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterDto userRegister)
    {
        var searchUser = await _unitOfWork.GenericRepository<User>().FindAsync(u => u.Email == userRegister.Email);
        if (!ModelState.IsValid||searchUser!=null)
        {
            return View();
        }
        
        PasswordHelper.CreatePasswordHash(userRegister.Password,out byte[] hash,out byte[] salt);
        var userModel = _mapper.Map<User>(userRegister);
        userModel.PasswordHash = Convert.ToBase64String(hash);
        userModel.PasswordSalt = Convert.ToBase64String(salt);
        await _unitOfWork.GenericRepository<User>().CreateAsync(userModel);
        await _unitOfWork.SaveAsync();
        return RedirectToAction("Index","Home");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }
}