using System.Runtime.Serialization;

namespace HomeFinance.Contract.Data
{
    [DataContract]
    public class Currency
    {
        public Currency(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Value { get; set; }
    }
}
