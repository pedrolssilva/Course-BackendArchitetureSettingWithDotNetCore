using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Course.Models
{
    public class FieldValidateViewModelOutput
    {
        public IEnumerable<string> Errors { get; private set; }

        public FieldValidateViewModelOutput(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
