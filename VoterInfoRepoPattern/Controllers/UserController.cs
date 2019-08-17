using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoterInfoRepoPattern.Models;

namespace VoterInfoRepoPattern.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public ToDoTaskContext _context;
        public UserController(ToDoTaskContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddUser( LoginForTheatre data)
        {

            string Hash=GeneratePasswordHash(data.Password);
            data.Password = Hash;
            _context.LoginForTheatre.Add(data);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult CheckUser(LoginForTheatre data)
        {
            string Hash=GeneratePasswordHash(data.Password);
            data.Password = Hash;
            bool result=_context.LoginForTheatre.Any(x => x.Username == data.Username && x.Password == data.Password);
            return Ok(result);
        }
        private string GeneratePasswordHash(string PassWord)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: PassWord,
                salt: Encoding.UTF8.GetBytes("nsdfaipshfmasdnoivnjpoasiuapo;jpoi[';;jij"),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }


    }


}