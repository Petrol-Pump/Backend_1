using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Petrol_Pump1.ModelPostgres;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Petrol_Pump1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly FdwmrdjxContext _context;

        public static User user = new User();
        private readonly IConfiguration _configuration;


        public AuthController(IConfiguration configuration, FdwmrdjxContext context)
        {
            _configuration = configuration;
            _context = context;


        }

        [Route("registration")]
        [HttpPost()]
        public async Task<ActionResult<User>> Register( UserDto userDto)
        {
           /* var user1 = new User()
            {
                UserName = " ",
                Role = " ",
                PasswordHarsh = null,
                PasswordSalt = null
            };*/
            createPasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt, userDto.Role);


            /*  user.PasswordSalt = passwordSalt;
              user.PasswordHarsh = passwordHash;
              user.UserName = userDto.UserName;
              user.Role = userDto.Role;*/













            var user1 = new User
            {
                UserName = userDto.UserName,
                Role = userDto.Role,
                PasswordHarsh = passwordHash,
                PasswordSalt = passwordSalt

            };

            Console.WriteLine(user.UserName);
            Console.WriteLine(user.PasswordHarsh);
            _context.Users.Add(user1);

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                return Conflict();
            }


            return Ok(user1);


        }


        [HttpPost("{id}")]
        public async Task<ActionResult<string>> Login(UserDto userDto, int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user.UserName != userDto.UserName)
            {
                return BadRequest("User Not Found");

            }

            if (!VerifyPasswordHash(userDto.Password, user.PasswordHarsh, user.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(user);


            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
               /* new Claim(ClaimTypes.Role,"Employee"),
                new Claim(ClaimTypes.Role, "Contractor")*/
            };


            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt, string role)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                





            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt )
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
              return computeHash.SequenceEqual(passwordHash);
            }

        }
    }
}
