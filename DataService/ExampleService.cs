using Definition.Interfaces;
using Definition.Interfaces.Repository;

namespace DataService
{
    /// <summary>
    /// Used to make authenticated calls to an API using REST and JWT
    /// </summary>
    public class ExampleService : IExampleService
    {

        IExampleRepository _exampleRepository;
        public ExampleService(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public string GetData()
        {

            // Call Repository get DTO's back

            // AutoMapper to Model reference (generic)

            

            return _exampleRepository.GetData();
        }
    }
}
