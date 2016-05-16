using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinance.Data.Impl
{
    internal class Initializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
    }
}
