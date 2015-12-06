using Definition.Interfaces.Repository;
using System;
using System.Net.Http.Headers;

namespace ApiRepository.Repository
{
    /// <summary>
    /// An example of authenticated calls to the API using a Bearer token
    /// </summary>
    public class ExampleRepository: BaseRepository, IExampleRepository
    {

        public ExampleRepository(string baseUrl, string entity)
        {
            _client.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/json"));

             
            if (baseUrl.EndsWith("/"))
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);

            if (entity.StartsWith("/"))
                entity = entity.Substring(1);

            _client.BaseAddress = new Uri(baseUrl + "/" + entity);
        }


        public string GetData() //(object model)
        {
            // AutoMap DTO back to model
            //AutoMapper.Mapper.CreateMap(typeof(dto), model.GetType())

            // Unit of Work to get from API

            return "Test Data From Repository"; // Call GET from BaseRepository to actually connect to an API
        }

        public void InjectAuthorizationHeader(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

    }
}
