using Application.RecurlyRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IRecurlyRepo _repository;
        
        public AccountController(IRecurlyRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult CreateAccount()
        {
            _repository.CreateAccount();
            return Ok();
        }
      
    }
}
