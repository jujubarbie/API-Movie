using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesRental.API.Infrastructure;
using MoviesRental.DAL.Models;
using MoviesRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthCustomerController : ControllerBase
    {
        private readonly AuthCustomerService _service;
        private readonly TokenService _tokenService;

        public AuthCustomerController(AuthCustomerService service, TokenService tokenService )
        {
            _service = service;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] Customer customer)
        {
            _service.Register(customer);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Customer customer)
        {
            customer = _service.Login(customer);
            if (customer is null)
            {
                return Unauthorized();
            }
            
            // si on a bien un user en retour ( autorisé, on lui genere un token
            customer.Token = _tokenService.GenerateToken(customer);
            return Ok(customer);
        }
    }
}
