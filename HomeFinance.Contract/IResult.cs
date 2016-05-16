using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinance.Contract
{
    public interface IResult<T>
    {
        bool IsSuccess { get; }
        string Message { get; }
        Exception Exception { get; }
        T Model { get; set; }
    }
}
