using AppBusiness.Models;
using AppBusiness.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCodeCoverage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] DepartmentModel model)
        {
            _service.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] DepartmentModel model)
        {
            _service.Update(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
