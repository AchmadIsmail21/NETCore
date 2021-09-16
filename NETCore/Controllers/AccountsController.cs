using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NETCore.Context;
using NETCore.Models;
using NETCore.Repository.Data;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NETCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly MyContext myContext;
        public IConfiguration configuration;
        AccountRepository repository;
        public AccountsController(IConfiguration configuration,AccountRepository account, MyContext myContext) : base(account)
        {
            this.configuration = configuration;
            this.repository = account;
            this.myContext = myContext;
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVm)
        {

            var login = repository.Login(loginVm);

            if (login == 0)
            {
                return NotFound(new
                {
                    status = HttpStatusCode.NotFound,
                    message = "Email Belum Terdaftar"
                });
            }
            else if (login == 1)
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Password Salah"
                });
            }
            else
            {
                var data = (from p in myContext.Persons
                            join a in myContext.Accounts 
                            on p.NIK equals a.NIK 
                            join ar in myContext.AccountRoles on
                            a.NIK equals ar.AccountNIK
                            join r in myContext.Roles on ar.RoleId
                            equals r.Id
                            where p.Email == $"{loginVm.Email}"
                            select new PayloadVM
                            { 
                                NIK = p.NIK,
                                Email = p.Email,
                                Role = r.RoleName
                            }).ToList();
                var claim = new List<Claim>();
                claim.Add(new Claim("NIK", data[0].NIK));
                claim.Add(new Claim("Email", data[0].Email));
                foreach (var d in data) {
                    claim.Add(new Claim("roles", d.Role));
                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                                                 configuration["Jwt:Audience"],
                                                 claim, expires: DateTime.UtcNow.AddDays(1),
                                                 signingCredentials: signIn
                                                );
                return Ok(new { 
                               status = HttpStatusCode.OK,
                               token = new JwtSecurityTokenHandler().WriteToken(token),
                               message = "Login Berhasil"
                });

                /*return Ok(new
                {
                    status = HttpStatusCode.OK,
                    message = "Login Berhasil"
                });*/
            }

        }

        [Authorize(Roles = "Manager")]
        [HttpGet("GetAllLogin")]
        public ActionResult GetLogin() {
            var get = repository.GetLogin();
            if (get != null)
            {
                return Ok(get);
            }

            return NotFound("Tidak ada Data");
        }

        [HttpPost("ForgotPassword")]
        public ActionResult ForgotPassword(ForgotPasswordVM forgotPassword) {
            var result = repository.ForgotPassword(forgotPassword);
            try {
            if (result == 100)
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Email Tidak ditemukan"
                });
            }
            
            } catch { 

            }
                return Ok(new
                {
                    status = HttpStatusCode.OK,
                    message = "Reset Password sudah dikirim ke email"
                });
        }
        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(ChangePassVM change) {
            var result = repository.ChangePassword(change);
            if (result == 100)
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Email Tidak Terdaftar"
                });
            }
            else if (result == 200)
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Password lama salah"
                });
            }
            else if (result == 300) {
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Password Baru Tidak sama"
                });
            }
                return Ok(new { 
                    status = HttpStatusCode.OK,
                    message = "Password Berhasil diubah"
                });
        }
    }
}
