using System.ServiceModel;

namespace EA6Soap.Services
{
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        string GetStudentInfo(string name);
    }
}
