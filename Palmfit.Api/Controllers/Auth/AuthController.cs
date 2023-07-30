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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepo _authRepo; 
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IAuthRepo authRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _authRepo = authRepo;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var user = new AppUser { UserName=model.Email, Email=model.Email, FirstName=model.FirstName, LastName=model.LastName, MiddleName=model.MiddleName, PhoneNumber=model.PhoneNumber, Address=model.Address};

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return BadRequest(ModelState);
                }
                else
                {
                    return Ok(new { Message = "User registration successful." });
                }

            }

        }







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
                    var token = GenerateJwtToken(user);

                    // Returning the token in the response headers
                    Response.Headers.Add("Authorization", "Bearer " + token);
                    
                    return Ok(new { Message = "Login successful." });

                }
            }
        }



        private string GenerateJwtToken(AppUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Set a default expiration in minutes if "AccessTokenExpiration" is missing or not a valid numeric value.
            if (!double.TryParse(jwtSettings["AccessTokenExpiration"], out double accessTokenExpirationMinutes))
            {
                accessTokenExpirationMinutes = 30; // Default expiration of 30 minutes.
            }

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(accessTokenExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        [HttpPost("sendotp")]
        public async Task<IActionResult> SendOTP([FromBody] EmailDto emailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid email format." });
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(emailDto.Email);
                if (user == null)
                {
                    return NotFound(new { Message = "User not found. Please check your email and try again." });
                }
                else
                { // Generate OTP (6-digit OTP in this example)
                    string otp = _authRepo.GenerateOTP();

                    // Save the OTP and its expiration in the user's data (in a real application, you might use a database)
                    _authRepo.SaveOTPInUserData(emailDto.Email, otp);

                    // Send the OTP to the user's email (replace this with your email sending implementation)
                    var feedBack = _authRepo.SendOTPByEmail(emailDto.Email, otp);

                    return Ok(new { Message = feedBack });
                } 
                
            }
        }



    }
}
