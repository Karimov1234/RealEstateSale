using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public class GenericResponseModel<T>
    {
        public int StatusCode { get; set; }
        public T? Data { get; set; }

    }
}
