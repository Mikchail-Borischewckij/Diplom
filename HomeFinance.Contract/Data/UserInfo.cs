﻿using System.Runtime.Serialization;

namespace HomeFinance.Contract.Data
{
    [DataContract]
    public class UserInfo
    {
        public UserInfo(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
