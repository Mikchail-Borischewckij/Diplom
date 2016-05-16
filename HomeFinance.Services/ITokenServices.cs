using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeFinance.Contract;
using HomeFinance.Contract.Authorization;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface ITokenServices
    {
        #region Interface member methods.
        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
		IResult<Token> GenerateToken(int userId);

        /// <summary>
        /// Function to validate token againt expiry and existance in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
		IResult<bool> ValidateToken(string tokenId);

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IResult<bool> DeleteByUserId(int userId);
        #endregion
    }
}
