using Definition.Interfaces.Repository;
using System;
using System.Net.Http.Headers;

namespace ApiRepository.Repository
{
    /// <summary>
    /// An example of authenticated calls to the API using a Bearer token
    /// </summary>
    public partial class ExampleRepository: BaseRepository, IExampleRepository
    {

        public ExampleRepository(string baseUrl, string entity) : base(baseUrl, entity)
        {

        }

       
    }
}
