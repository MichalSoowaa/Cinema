using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace SzkolenieTechniczne2.Cinema.Domain.Command
{
    public class Result
    {
        private Result(bool isSuccess, string message, IEnumerable<Error> errors)
        {
            IsSuccess = isSuccess;
            IsFailure = !isSuccess;
            Message = message;
            Errors = errors;
        }

        public string Message { get; }
        public bool IsFailure { get; }
        public bool IsSuccess { get; }
        public IEnumerable<Error> Errors { get; }

        public static Result Fail(string message) => new Result(false, message, Enumerable.Empty<Error>());

        public static Result Fail(FluentValidation.Results.ValidationResult validationResult)
            => new Result(
                false,
                string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
                validationResult.Errors.Select(x => new Error(x.PropertyName, x.ErrorMessage)));

        public static Result Ok() => new Result(true, "", Enumerable.Empty<Error>());

        public class Error
        {
            public Error(string propertyName, string message)
            {
                PropertyName = propertyName;
                Message = message;
            }

            public string PropertyName { get; set; }
            public string Message { get; set; }
        }
    }
}
