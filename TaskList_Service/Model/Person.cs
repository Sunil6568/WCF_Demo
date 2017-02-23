using System.Runtime.Serialization;

namespace TaskList_Service.Model
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Fullname { get; set; }

        [DataMember]
        public string Profession { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}