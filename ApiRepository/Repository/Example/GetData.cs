using Definition.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository.Repository
{
    public partial class ExampleRepository
    {

        public List<ExampleDto> GetData()
        {
            //TODO: Actually connect to the sample API

            var list = new List<ExampleDto>();

            list.Add(new ExampleDto() { id = Guid.NewGuid(), name = "Demo One" });

            return list;
        }

    }
}
