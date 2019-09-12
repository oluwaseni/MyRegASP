using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForUserRegistration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForUserRegistration.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }


        [HttpGet]
        [Authorize]
        //GET : /API/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };

        }
    }
}