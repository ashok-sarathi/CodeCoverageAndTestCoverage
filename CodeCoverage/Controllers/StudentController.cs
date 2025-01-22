using AppBusiness.Models;
using AppBusiness.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCodeCoverage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
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
        public IActionResult Post([FromBody] StudentModel model)
        {
            _service.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] StudentModel model)
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
