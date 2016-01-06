using Definition.Dto;
using Definition.Interfaces;
using Definition.Interfaces.Repository;
using System.Collections.Generic;

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

        public List<ExampleDto> GetData()
        {
            // You could call other services or do some data aggregation or manipulation at this point.
            // Otherwise you might as well call direct to the repository

            return _exampleRepository.GetData();
        }
    }
}
