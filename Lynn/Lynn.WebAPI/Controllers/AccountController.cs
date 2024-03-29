﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Lynn.DAL.Identity;
using Lynn.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lynn.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterUserDTO registerUserDTO)
        {
            var user = new ApplicationUser
            {
                UserName = registerUserDTO.UserName,
                Email = registerUserDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);

            if (!string.IsNullOrEmpty(registerUserDTO.Level))
            {
                await _userManager.AddClaimAsync(
                        user,
                        new Claim(nameof(registerUserDTO.Level), 
                        registerUserDTO.Level)
                    );
            }

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    return BadRequest(error.Code);
                }
                return BadRequest();
            }
        }
    }
}