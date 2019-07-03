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
    [Route("api/[controller]/[action]"), Authorize]
    public class ProductController : BaseAPI<Product>
    {
        IRepository<Product> _repository;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IRepository<Product> repository, ILogger<ProductController> logger) : base(repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult UserProducts(string userid)
        {
            var products = _repository.Get(x => x.UserId == userid);
            return Ok(products);
        }
    }
}