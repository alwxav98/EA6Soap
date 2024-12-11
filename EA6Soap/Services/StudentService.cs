namespace EA6Soap.Services
{
    public class StudentService : IStudentService
    {
        public string GetStudentInfo(string name)
        {
            return $"Estudiante: {name}, Universidad Central del Ecuador";
        }
    }
}