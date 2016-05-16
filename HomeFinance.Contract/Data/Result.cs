using System;
using System.Runtime.Serialization;

namespace HomeFinance.Contract.Data
{
    public class Result<T> : IResult<T>
    {
        public Result(bool result)
        {
            IsSuccess = result;
        }

        public Result(bool result, string message)
            : this(result)
        {
            Message = message;
        }

        public Result(bool result, T model)
            : this(result)
        {
            IsSuccess = result;
            Model = model;
        }

        public Result(bool result, string message, Exception exception)
            : this(result, message)
        {
            Exception = exception;
        }

        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public T Model { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public Exception Exception { get; set; }
    }
}
