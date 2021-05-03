using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sampleApi.Utils.PostPutPatchReturn.Models;

namespace sampleApi.Utils.PostPutPatchReturn.Repositories
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private MyDbContext _context;

        public StudentRepository(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public async Task<Student> GetStudentByID(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public void InsertStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void DeleteStudent(int studentID)
        {
            Student student = _context.Students.Find(studentID);
            _context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public async Task<bool> SaveAsync()
        {
            var changedRecordNum = await _context.SaveChangesAsync();

            if (changedRecordNum > 0)
            {
                return true;
            }

            return false;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}