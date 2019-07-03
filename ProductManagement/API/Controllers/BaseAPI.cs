using BLL;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseAPI<T> : ControllerBase where T : BaseEntity
    {
        private IRepository<T> _repository;
        public BaseAPI(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            T entity = _repository.Get(x => x.Id == id).FirstOrDefault();
            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<T> entities = _repository.Get();
            return Ok(entities);
        }

        [HttpPost]
        public virtual IActionResult Add(T entity)
        {
            CrudState state = _repository.Add(entity);
            if (state == CrudState.Success)
                return Created("/" + typeof(T).Name + "/" + entity.Id, entity);
            else
                return Conflict();
        }

        [HttpPost]
        public IActionResult AddRange(List<T> entity)
        {
            CrudState state = _repository.Add(entity);
            if (state == CrudState.Success)
                return Created("/" + typeof(T).Name,entity);
            else
                return Conflict();//hata durumu dönebiliriz
        }


        [HttpPut]
        public IActionResult Update(T entity) // updaterange yapılabilir.
        {
            CrudState state = _repository.Update(entity);
            if (state == CrudState.Success)
                return Ok(entity);
            else
                return NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            CrudState state = _repository.Delete(id);
            if (state == CrudState.Success)
                return Ok(true);
            else
                return NotFound(false);
        }

    }
}
