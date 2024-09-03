using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WbApiDemo3_22_5.Dtos;
using WbApiDemo3_22_5.Entities;
using WbApiDemo3_22_5.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WbApiDemo3_22_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<StudentDto>> Get()
        {
            var items = await _studentService.GetAllAsync();
            var dataToReturn = items.Select(s =>
            {
                return new StudentDto
                {
                    Id = s.Id,
                    Age = s.Age,
                    Fullname = s.Fullname,
                    Score = s.Score,
                    SeriaNo = s.SeriaNo,
                };
            });
            return dataToReturn;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _studentService.GetAsync(s => s.Id == id);
            if (item == null) return NotFound();
            var dto = new StudentDto
            {
                Id = item.Id,
                Age = item.Age,
                Fullname = item.Fullname,
                Score = item.Score,
                SeriaNo = item.SeriaNo,
            };
            return Ok(dto);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentAddDto dto)
        {
            var entity = new Student
            {
                SeriaNo = dto.SeriaNo,
                Score = dto.Score,
                Fullname = dto.Fullname,
                Age = dto.Age,
            };
            await _studentService.AddAsync(entity);
            return Ok(dto);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
