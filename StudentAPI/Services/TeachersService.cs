using Microsoft.EntityFrameworkCore;
using StudentAPI.Interfaces;
using StudentDAL.Models;

namespace StudentAPI.Services
{
    public class TeachersService : ITeachers
    {
        private readonly studentContext _context;

        public TeachersService(studentContext studentContext)
        {
            _context = studentContext;
        }

        public async Task DeleteTeacher(int id)
        {

            var teacher = await _context.Teachers.FindAsync(id);

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

        }

        public async Task<Teacher> getTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            return teacher;
        }

        public async Task<IEnumerable<Teacher>> getTeachers()
        {
            var teacherList = await _context.Teachers.ToListAsync();

            return teacherList;
        }

        public async Task<Teacher> PostTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task PutTeacher(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private bool TeacherExists(int id)
        {
            return (_context.Teachers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
