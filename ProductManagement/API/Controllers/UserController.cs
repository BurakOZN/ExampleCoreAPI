using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class UserController : BaseAPI<User>
    {
        IRepository<User> _repository;
        private readonly ILogger<UserController> _logger;
        public UserController(IRepository<User> repository, ILogger<UserController> logger) : base(repository)
        {
            _repository = repository;
            _logger = logger;
        }
        [AllowAnonymous]
        public override IActionResult Add(User entity)
        {
            return base.Add(entity);
        }
    }
}