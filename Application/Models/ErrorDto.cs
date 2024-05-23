using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ErrorDto
    {
        public List<String>? Errors { get; private set; } = new List<String>();

        public ErrorDto(string error)
        {
            Errors.Add(error);
        }

        public ErrorDto(List<string> errors)
        {
            Errors = errors;
        }

        public ErrorDto()
        {

        }
    }
}
