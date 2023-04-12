//using TeacherDAL.Models;

using StudentDAL.Models;

namespace StudentAPI.Interfaces
{
    public interface ITeachers
    {
        Task<Teacher> getTeacher(int id);

        Task<IEnumerable<Teacher>> getTeachers();

        Task PutTeacher(Teacher teacher);

        Task<Teacher> PostTeacher(Teacher teacher);

        Task DeleteTeacher(int id);
    }
}
