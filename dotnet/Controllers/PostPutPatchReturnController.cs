using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Utils.PostPutPatchReturn.Core;
using sampleApi.Utils.PostPutPatchReturn.Models;
using sampleApi.Utils.PostPutPatchReturn.Repositories;

namespace sampleApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostPutPatchReturnController : CommonControllerLogics
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

        /// <summary>
        /// Create a new student
        /// </summary>
        /// <param name="student">student info, in json format in request body</param>
        /// <param name="isReturnObject">true if the client want to confirmed the student was inserted to the database</param>
        /// <returns>the student or 200 ok status code</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student, bool isReturnObject)
        {
            _studentRepository.InsertStudent(student);
            var isSuccess = await _studentRepository.SaveAsync();

            return HandleReturnObjectLogic(isSuccess, isReturnObject, student, "Cannot insert new student");
        }

        [HttpPut]
        public async Task<IActionResult> ChangeStudentEmail([FromBody] Student student, bool isReturnObject)
        {
            var dbStudent = await _studentRepository.GetStudentByID(student.Id);
            dbStudent.Email = student.Email;

            var isSuccess = await _studentRepository.SaveAsync();

            return HandleReturnObjectLogic(isSuccess, isReturnObject, dbStudent, "Cannot change student email");
        }
    }
}