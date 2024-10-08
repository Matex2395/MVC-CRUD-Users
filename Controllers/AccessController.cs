﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_Users.Models;
using MVC_CRUD_Users.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MVC_CRUD_Users.Controllers
{
    public class AccessController : Controller
    {
        private readonly MvccrudusersContext _db;

        public AccessController(MvccrudusersContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserVM model)
        {
            if(model.Password != model.ConfirmPassword)
            {
                ViewData["Message"]= "Las contraseñas no coinciden";
                return View();
            }

            User user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Role = "User"
            };

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            if(user.Id != 0) return RedirectToAction("Login","Access");

            ViewData["Message"] = "Ha ocurrido un error al registrar el usuario.";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            User? found_user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if(found_user == null)
            {
                ViewData["Message"] = "No se encontraron coincidencias.";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, found_user.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity), 
                properties);
            return RedirectToAction("Index", "Home");

        }
    }
}
