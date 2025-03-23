using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Common
{
    public class Result<T>
    {
        public T? Data { get; set; }
        public List<string> ErrorMessages { get; set; } = [];

        public Result() { }

        private Result(T? data, params string[] errorMessages)
        {
            Data = data;
            ErrorMessages = [.. errorMessages];
        }

        public static Result<T> Success(T data) => new(data);
        public static Result<T> Failure(params string[] errorMessages) => new(default, errorMessages);

        public bool HasError() => Data is null;
    }

}
