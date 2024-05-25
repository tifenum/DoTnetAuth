using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUser{userId}")]
        public ActionResult GetUserById([FromRoute] int userId)
        {
            var user = _userService.GetUserById(userId);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost("Register")]
        public ActionResult RegisterUser([FromBody] User user)
        {
            var registeredUser = _userService.RegisterUser(user.Username, user.Password, user.Email);
            return Ok(registeredUser);
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] User credentials)
        {
            var user = _userService.GetUserByUsername(credentials.Username);
            if (user == null || user.Password != credentials.Password)
                return Unauthorized();


            return Ok("Login successful");
        }

        [HttpPost("Logout")]
        public ActionResult Logout()
        {
            return Ok("Logout successful");
        }

        [HttpPut("Modify{userId}")]
        public ActionResult UpdateUser([FromRoute] int userId, [FromBody] User user)
        {
            var existingUser = _userService.GetUserById(userId);
            if (existingUser == null)
                return NotFound();


            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;

            _userService.UpdateUser(existingUser);
            return Ok(existingUser);
        }

        [HttpPost("ForgotPassword")]
        public ActionResult ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            try
            {
                var user = _userService.GetUserByEmail(request.Email);
                if (user == null)
                    return NotFound("User not found");

                string token = GeneratePasswordResetToken(user);
                string resetPasswordLink = $"https://localhost:7080/User/ResetPassword/{token}";


                return Ok(resetPasswordLink);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during password reset: {ex.Message}");    
                return StatusCode(500, "An error occurred during password reset");
            }
        }

        [HttpPost("ResetPassword/{token}")]
        public ActionResult ResetPassword([FromRoute] string token,[FromBody] ResetPasswordRequest request)
        {
            try
            {
                var user = _userService.GetUserByEmail(request.Email);
                if (user == null)
                    return NotFound("User not found");

                if (!ValidatePasswordResetToken(token))
                    return BadRequest("Invalid token");

                _userService.UpdatePassword(user, request.NewPassword);

                return Ok("Password reset successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during password reset: {ex.Message}");
                return StatusCode(500, "An error occurred during password reset");
            }
        }


        private string GeneratePasswordResetToken(User user)
        {
            return Guid.NewGuid().ToString();
        }


        private bool ValidatePasswordResetToken(string token)
        {
            return !string.IsNullOrEmpty(token);
        }
    }

    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
    }
}
