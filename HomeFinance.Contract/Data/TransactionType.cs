using System;

namespace HomeFinance.Contract.Data
{
    [Serializable]
    public enum TransactionType
    {
        None=0,
        Single=1,
        Mountly=2
    }
}
