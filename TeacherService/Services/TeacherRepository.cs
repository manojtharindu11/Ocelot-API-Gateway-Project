

using TeacherService.Model;
using TeacherService.Services;

namespace TeacherService.Service
{
    public class TeacherRepository : List<Model.Teacher>, ITeacherRepository
    {

        private readonly static List<Model.Teacher> _teachers = TeacherSeed();

        private static List<Teacher> TeacherSeed()
        {
            var result = new List<Teacher>()
            {
                new Teacher()
                {
                    Id = 1,
                    Name = "Teacher1",
                    School = "TeacherSchool1"

                },
                new Teacher()
                {
                    Id = 2,
                    Name = "Teacher2",
                    School = "TeacherSchool2"
                },
                new Teacher()
                {
                    Id = 3,
                    Name = "Teacher3",
                    School = "TeacherSchool3"
                }

            };

            return result;
        }
        public List<Teacher> GetAll()
        {
            return _teachers;
        }

        public Teacher Get(int id)
        {
            return _teachers.Find(teacher => teacher.Id == id);
        }
    }
}
