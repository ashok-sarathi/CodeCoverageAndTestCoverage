using AppBusiness.Models;
using AppBusiness.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCodeCoverage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
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
        public IActionResult Post([FromBody] EmployeeModel model)
        {
            _service.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] EmployeeModel model)
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
