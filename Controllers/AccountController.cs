using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using market.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        [HttpPost("action")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel formdata)
        {
            // Will Hold all The errors related to Registration
            List<string> errorList = new List<string> {};

            var user = new IdentityUser
            {
                Email = formdata.Email,
                UserName = formdata.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, formdata.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");

                return Ok(new {username = user.UserName ,email = user.Email, status = 1,message ="Registeration Succesful"});
                
            }

            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    errorList.Add(error.Description);
                }
            }
            return BadRequest(new JsonResult(errorList));
        }
    }
}