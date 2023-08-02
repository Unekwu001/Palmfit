using Data.Entities;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.AuthRepository
{
    public interface IAuthRepo
    {
        string GenerateJwtToken(AppUser user);
        string SendOTPByEmail(string email, string otp);
        void SaveOTPInUserData(string email, string otp);
        string GenerateOTP();
        UserOTP GetValidOTP(string email, string otp);

    }
}
