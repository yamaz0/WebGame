using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Response
{
    public class BasicResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }

        public BasicResponse(bool succes = true)
        {
            Init(succes);
        }

        public BasicResponse(List<string> errors) : this(false)
        {
            foreach (var error in errors)
            {
                Errors.Add(error);
            }
        }

        public BasicResponse(string error) : this(false)
        {
            Errors.Add(error);
        }

        public BasicResponse(ValidationResult result)
        {
            bool isSuccesful = CheckResult(result);

            Init(isSuccesful);

            foreach (var error in result.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }

        private void Init(bool succes)
        {
            Errors = new List<string>();
            Success = succes;
        }

        private bool CheckResult(ValidationResult result)
        {
            return !result.Errors.Any();
        }
    }
}
