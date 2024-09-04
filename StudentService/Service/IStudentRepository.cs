namespace StudentService.Service
{
    public interface IStudentRepository
    {
        List<Model.Student> GetAll();

        Model.Student GetById(int id);
    }
}
