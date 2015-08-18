using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition.Model
{
    public class Result<T>
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Value { get; set; }
    }
}
