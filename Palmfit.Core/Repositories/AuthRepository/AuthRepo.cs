using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Palmfit.Data.AppDbContext;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Palmfit.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Repositories.AuthRepository 
{
    public class AuthRepo : IAuthRepo
    {
        private readonly PalmfitDbContext _palmfitDbContext;
        private readonly IConfiguration _configuration;
        public AuthRepo(PalmfitDbContext palmfitDbContext, IConfiguration configuration)  
        {
            _palmfitDbContext = palmfitDbContext;
            _configuration = configuration;
        }
 

        public string GenerateJwtToken(AppUser user)
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





        public string SendOTPByEmail(string email, string otp)
            {
                try
                {
                    // Replace these with your SMTP server settings and credentials
                    string smtpServer = "smtppro.zoho.com";
                    int smtpPort = 587;
                    string smtpUsername = "info@enema.ng";
                    string smtpPassword = "-8qijjUd";

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(smtpUsername);
                        mailMessage.To.Add(email);
                        mailMessage.Subject = "One-Time Password (OTP)";
                        mailMessage.Body = $"Your OTP: {otp}";

                        using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                        {
                            smtpClient.EnableSsl = true;
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                            smtpClient.Send(mailMessage);
                        }
                    }

                    return $"OTP sent to {email}";
                }
                catch (Exception ex)
                {
                    // Handle any exception that might occur during email sending
                    return $"Failed to send OTP to {email}. Error: {ex.Message}";
                }
            }



            public void SaveOTPInUserData(string email, string otp)
            {
                var userOTP = new UserOTP
                {
                    Email = email,
                    OTP = otp,
                    Expiration = DateTime.UtcNow.AddMinutes(10) // Set an expiration time for the OTP (e.g., 10 minutes in this code)
                };

                _palmfitDbContext.UserOTPs.Add(userOTP);
                _palmfitDbContext.SaveChanges();
            }


            public string GenerateOTP()
            {
                // Generate a 6-digit OTP (you can adjust the length as needed)
                Random random = new Random();
                int otpValue = random.Next(100000, 999999);
                return otpValue.ToString();
            }



        public UserOTP GetValidOTP(string email, string otp)
        {
            var validOTP = _palmfitDbContext.UserOTPs.FirstOrDefault(Otp => Otp.Email == email && Otp.OTP == otp && Otp.Expiration >= DateTime.UtcNow);

            if (validOTP != null && validOTP.Expiration < DateTime.UtcNow)
            {
                // If the OTP has expired, remove it from the database
                _palmfitDbContext.UserOTPs.Remove(validOTP);
                _palmfitDbContext.SaveChanges();
                validOTP = null; // Set the result to null to indicate that the OTP has expired
            }
            return validOTP;
        }





    }
}

