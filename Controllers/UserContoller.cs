using System.Net;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TamsaApi.Domain.BaseDomain;
using TamsaApi.Domain.Entity;
using TamsaApi.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using tTamsaApi.Domain.BaseDomain;
using PocketBook.Core.IConfiguration;

namespace TamsaApi.TamsaApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserContoller : ControllerBase
    {
        private readonly ILogger<UserContoller> _logger;
        private IUnitOfWork _unitOfWork ;

        public UserContoller(ILogger<UserContoller> logger, IUnitOfWork unitOfWork)
        { 
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        //     public UserContoller(TamsaApisaContext TamsaApisaContext, ILogger<UserContoller> logger, IuserReposetory userReposetory)
        //     {
        //  //       _TamsaApisaContext = TamsaApisaContext;
        //         _logger = logger;
        //  //       _userReposetory = userReposetory;
        //     }
        [HttpPost]
        public IActionResult RegisterUser(RegisterUserDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data ");

            // if (!string.IsNullOrEmpty(input?.UserName) || !string.IsNullOrEmpty(input?.PhoneNumber)
            // || !string.IsNullOrEmpty(input?.Email) || !string.IsNullOrEmpty(input?.Password)
            // || !string.IsNullOrEmpty(input?.RepeatPassword))
            //     return BadRequest("Invalid data ");



            // if(input.Password != input.RepeatPassword );
            //     return BadRequest("the password in not match ");


            // if(input.Password.Length <9)
            //     return BadRequest("is not a strong password !");


            // if( !input.Email.Contains("@gmail.com") || !input.Email.Contains("@yahoo.com"));
            //     return BadRequest("this is not a email");

            var existUserEmail =  _unitOfWork.Users.isExistByEmail(input.Email.ToLower());

            if (existUserEmail is true)
                return BadRequest("this is not a email");


            var existUserPhoneNumber = _unitOfWork.Users.isExistByPhoneNumber(input.PhoneNumber);


            if (existUserPhoneNumber is true)
                return BadRequest("this is not a email");


            // var existUser = _TamsaApisaContext.CustomerTb.FirstOrDefault(x => x.UserName.Equals(input.UserName));


            // if(existUser != null)
            //     return BadRequest("this is not a email");


            var instance = new CustomerEntity(input.UserName, input.Email.ToLower(), input.PhoneNumber, input.Password);
            _unitOfWork.Users.Add(instance);
            return Ok(instance.Id);
        }



        [HttpGet]
        public IActionResult Login(LoginInWhiteEmailAddressPutDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest();



            var cus = _unitOfWork.Users.LogingWhiteEmail(input.emailAddress.ToLower(), input.Password);



            if (cus is null)
                return BadRequest();
            var claimes = new List<Claim>()
                {
                   new Claim(ClaimTypes.NameIdentifier,cus.Id),
                   new Claim(ClaimTypes.Name, cus.UserName)
                }; ///bara geterdtane etlate jari user va qara daadane bara cookie 
            var identity = new ClaimsIdentity(claimes, CookieAuthenticationDefaults.AuthenticationScheme);
            ///be system mifahmonim ke az che noyiaz ClimesIdentity estefade mikand  
            var principle = new ClaimsPrincipal(identity);
            var propertoes = new AuthenticationProperties()
            {
                IsPersistent = input.RememeberMe
            };
            HttpContext.SignInAsync(principle, propertoes);
            return Ok();
        }


        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}