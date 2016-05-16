using System;
using System.Runtime.Serialization;

namespace HomeFinance.Contract.Data
{
   [DataContract]
   public class IncomePlaning : TransactionPlaning
   {
       public IncomePlaning(int id, double amount,DateTime date,int accountId,int categoryId)
           : base(id, amount,date,accountId, categoryId)
       {

       }
   }
}
