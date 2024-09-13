using eCommerce.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class UserController : Controller
    {
        MyContext db = new MyContext();

        // GET: Register - Display registration form
        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }

        // POST: Register - Action to handle registration
        [HttpPost]
        public IActionResult Register(User user)
        {
            // Validate the input
            if (ModelState.IsValid)
            {
                User acc = new User();
                acc.Email = user.Email;
                acc.FirstName = user.FirstName;
                acc.LastName = user.LastName;
                acc.Password = user.Password;

                db.Users.Add(acc);
                db.SaveChanges();
                ModelState.Clear();

                // Redirect to the Login action after successful registration
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: Login - Display login form
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login - Action to handle login
        [HttpPost]
        public IActionResult Login(User user)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View();
            }

            // Check if the user exists in the database
            var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (existingUser != null)
            {
                // After successful login, redirect to the Products page
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View();
            }
        }
    }
}
