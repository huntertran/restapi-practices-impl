using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sampleApi.Utils.PostPutPatchReturn.Models;

namespace sampleApi.Utils.PostPutPatchReturn.Repositories
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Task<Student> GetStudentByID(int studentId);
        void InsertStudent(Student student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Student student);
        Task<bool> SaveAsync();
    }
}