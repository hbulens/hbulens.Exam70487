using System.Runtime.Serialization;

namespace hbulens.Exam70487.Common
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int Id { get; set; }
    }
}