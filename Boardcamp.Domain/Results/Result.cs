using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Domain.Results
{
    public class Result<T>
    {
        private Result(){}

        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public T? Value { get; private set; }
        public string? ErrorMessage { get; private set; }

        internal static Result<T> Success(T value)
        {
            return new Result<T> { IsSuccess = true, Value = value };
        }

        internal static Result<T> Failure(string errorMessage)
        {
            return new Result<T> { IsSuccess = false, ErrorMessage = errorMessage };
        }
    }

    public class Result
    {
        private Result() { }

        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public string? ErrorMessage { get; private set; }

        public static Result<T> Success<T>(T value)
        {
            return Result<T>.Success(value);
        }

        public static Result Success()
        {
            return new Result { IsSuccess = true };
        }

        public static Result<T> Failure<T>(string errorMessage)
        {
            return Result<T>.Failure(errorMessage);
        }

        public static Result Failure(string errorMessage)
        {
            return new Result { IsSuccess = false, ErrorMessage = errorMessage };
        }
    }
}
