using StudentService.Model;

namespace StudentService.Service
{
    public class StudentRepository : List<Model.Student>, IStudentRepository
    {

        private readonly static List<Model.Student> _students = StudentSeed();

        private static List<Student> StudentSeed()
        {
            var result = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Name = "Student1",
                    School = "School1"
                  
                },
                new Student()
                {
                    Id = 2,
                    Name = "Student2",
                    School = "School2"
                },
                new Student()
                {
                    Id = 3,
                    Name = "Student3",
                    School = "School3"
                }

            };

            return result;
        }
        public List<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.Find(student => student.Id == id);
        }
    }
}
