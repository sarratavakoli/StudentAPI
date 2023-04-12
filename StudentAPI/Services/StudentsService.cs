using Microsoft.EntityFrameworkCore;
using StudentAPI.Interfaces;
using StudentDAL.Models;

namespace StudentAPI.Services
{
    public class StudentsService : IStudents
    {
        private readonly studentContext _context;

        public StudentsService(studentContext studentContext)
        {
            _context = studentContext;
        }

        public async Task DeleteStudent(int id)
        {

            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

        }

        public async Task<Student> getStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            return student;
        }

        public async Task<IEnumerable<Student>> getStudents()
        {
            var studentList = await _context.Students.ToListAsync();

            return studentList;
        }

        public async Task<Student> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task PutStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
