﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebSpa.TypeScript.Models;
using WebSpa.TypeScript.Services;

namespace WebSpa.TypeScript.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private AccountService AccountService { get; set; }

        public AccountController(AccountService accountService)
        {
            AccountService = accountService;
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody]LoginModel model)
        {
            var result = AccountService.Login(HttpContext, model.Login, model.Password);
            return Json(result);
        }

        [HttpPost("[action]")]
        public IActionResult Logout()
        {
            var result = AccountService.Logout(HttpContext);
            return Json(result);
        }
    }
}
