using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sampleApi.Utils.PostPutPatchReturn
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Task<Student> GetStudentByID(int studentId);
        void InsertStudent(Student student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Student student);
        Task Save();
    }
}