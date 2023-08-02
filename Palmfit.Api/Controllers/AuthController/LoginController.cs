using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Palmfit.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Palmfit.Data.Dtos;
using Core.Repositories.AuthRepository;
using API.Data.Auth;

namespace Palmfit.Api.Controllers
{ 
    public partial class UserOnboarding
    {


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return BadRequest(new { Message = "Invalid request. Please provide valid email and password." });
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(login.Email);

                if (user == null)
                {
                    return NotFound(new { Message = "User not found. Please check your email and try again." });
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    return Unauthorized(new { Message = "Invalid credentials. Please check your email or password and try again." });
                }
                else
                {
                    var token = _authRepo.GenerateJwtToken(user);

                    // Returning the token in the response headers
                    Response.Headers.Add("Authorization", "Bearer " + token);

                    return Ok(new { Message = "Login successful." });

                }
            }
        }



       


    }
}