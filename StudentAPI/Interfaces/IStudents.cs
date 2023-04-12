using StudentDAL.Models;

namespace StudentAPI.Interfaces
{
    public interface IStudents
    {
        Task<Student> getStudent(int id);

        Task<IEnumerable<Student>> getStudents();

        Task PutStudent(Student student);

        Task<Student> PostStudent(Student student);

        Task DeleteStudent(int id);
    }
}
