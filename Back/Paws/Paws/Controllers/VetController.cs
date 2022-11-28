using Application.Interfaces;
using Application.Main.Helper;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Paws.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VetController : ControllerBase
    {
        private readonly IVetApplication _vetApplication;
       // private readonly Jwt _jwt;

        public VetController(IVetApplication vetApplication)
        {
            _vetApplication = vetApplication;


        }
        [HttpPost]
        public async Task<IActionResult> CreateVet([FromBody] Vet vet)
        {
            var response = await _vetApplication.CreateVet(vet);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVet([FromBody] Vet vet)
        {
            var response = await _vetApplication.UpdateVet(vet);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVet([FromBody] string nit)
        {
            var response = await _vetApplication.DeleteVet(nit);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }



        //[HttpPost]
        //public async Task<IActionResult> AuthenticateVet([FromBody] Vet vet)
        //{

        //    var response = await _vetApplication.AuthenticateVet(vet.user, vet.Password);

        //    if (response.IsSuccess)
        //    {
        //        response.Data = BuildToken();
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return BadRequest(response);
        //    }
        //}

        //private string BuildToken()
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_jwt.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Expires = DateTime.UtcNow.AddDays(5),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
        //        Issuer = _jwt.IsSuer,
        //        Audience = _jwt.Audience
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);
        //    return tokenString;
        //}



    }
}
