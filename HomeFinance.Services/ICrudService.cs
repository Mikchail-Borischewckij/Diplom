using System.Collections.Generic;
using HomeFinance.Contract;

namespace HomeFinance.Services
{
    public interface ICrudService<T> 
    {
        IResult<T> Create(T item);

        T Read(int itemId);

        IResult<T> Update(T item);

        IResult<bool> Delete(int itemId);

        IEnumerable<T> ReadAll();
    }
}
