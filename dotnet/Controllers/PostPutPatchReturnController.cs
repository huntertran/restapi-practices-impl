using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Utils.PostPutPatchReturn;

namespace sampleApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostPutPatchReturnController : ControllerBase
    {
        private IStudentRepository _studentRepository;

        public PostPutPatchReturnController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetStudents();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student, bool isReturnObject)
        {
            _studentRepository.InsertStudent(student);
            var isSuccess = await _studentRepository.SaveAsync();

            if (isSuccess)
            {
                if (isReturnObject)
                {
                    return Ok(student);
                }
                else
                {
                    return Ok();
                }
            }

            return StatusCode(500, "Cannot insert new student");
        }
    }
}