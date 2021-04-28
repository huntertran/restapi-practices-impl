using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Utils;
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

        [HttpPost]
        public async Task<IActionResult> Create(Student student, bool isReturnObject)
        {
            _studentRepository.InsertStudent(student);
            await _studentRepository.Save();

            if (isReturnObject)
            {
                var newStudent = await _studentRepository.GetStudentByID(1);
                return Ok(newStudent);
            }
            else
            {
                return Ok();
            }
        }
    }
}