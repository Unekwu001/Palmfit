using API.Data.Auth;
using Data.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Palmfit.Data.Entities;
using Palmfit.Data.Dtos;
using Core.Repositories.AuthRepository;


namespace Palmfit.Api.Controllers
{
    public partial class UserOnboarding
    {

        [HttpPost("validateotp")]
        public IActionResult ValidateOtp([FromBody] ValidateOtpDto validateOtpDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid request data." });
            }
            else
            {
                 
                // Get the user's OTP data from the repository
                var validUserOTP = _authRepo.GetValidOTP(validateOtpDto.Email, validateOtpDto.Otp);

                // Check if the OTP exists and has not expired
                if (validUserOTP == null)
                {
                    return BadRequest(new { Message = "OTP has expired or does not exist." });
                }

                // Valid OTP
                return Ok(new { Message = "Valid OTP." });
            }
        }


    }

}
