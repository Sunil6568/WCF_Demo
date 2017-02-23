using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using TaskList_Service.Model;

namespace TaskList_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITaskService" in both code and config file together.
    [ServiceContract]
    public interface ITaskService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetAllTask/")]
        List<Person> GetAllTask();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetTaskById/")]
        Person GetTaskById(int id);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddNew")]
        bool AddNew(Person task);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/UpdateTask")]
        void UpdateTask(Person contact);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteTask/{TaskId}")]
        void DeleteTask(Person task);
    }
}
