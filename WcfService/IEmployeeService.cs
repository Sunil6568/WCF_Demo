using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        //[OperationContract]
        //string GetAll(int value);

        [OperationContract]
        List<Person> GetAll();

        [OperationContract]
        Person GetDataUsingDataContract(Person composite);

        [OperationContract]
        [WebGet]
        List<Person> GetBooksList();

        [OperationContract]
       // [WebGet(UriTemplate = "Book/{id}")]
        Person GetBookById(int id);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddBook/{name}")]
        void AddBook(string name);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateBook/{id}/{name}")]
        void UpdateBook(string id, string name);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteBook/{id}")]
        void DeleteBook(string id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<string> GetBooksNames();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfService.ContractType".
    [DataContract]
    public class Person
    {

      //  public int Id { get; set; }

       // public String Fullname { get; set; }

        //public String Profession { get; set; }

        //public int Age { get; set; }

      
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
