using System;

namespace HomeFinance.Contract.Authorization
{
    public class Token
    {
        public Token(int id,int userId,string authToken,DateTime issueOn,DateTime expiresOn)
        {
            Id = id;
            UserId = userId;
            AuthToken = authToken;
            IssueOn = issueOn;
            ExpiresOn = expiresOn;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string AuthToken { get; set; }
        public DateTime IssueOn { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
