using Definition.Interfaces;
using Definition.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _exampleRepository.GetData();
        }
    }
}
