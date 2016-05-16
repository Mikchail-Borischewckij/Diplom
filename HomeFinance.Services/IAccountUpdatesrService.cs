using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeFinance.Contract;

namespace HomeFinance.Services
{
    public interface IAccountUpdatesrService
    {
        IResult<bool> UpdateAccounts();
    }
}
