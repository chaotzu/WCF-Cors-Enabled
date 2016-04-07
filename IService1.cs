using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Wcf.App
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "GetData?param={value}")]
        string Anymethod(int value);

        [OperationContract]
        [WebInvoke(UriTemplate = "/TestMethod", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json
          )]
        string TestMethod(CompositeType value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);


        [OperationContract]
        [WebGet(UriTemplate = "/Empleados", ResponseFormat = WebMessageFormat.Json)]
        Employee[] Empleados();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Cargar", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        String Upload(Stream Uploading);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string DeptName { get; set; }
    }

    [DataContract]
    public class CargarArchivo
    {
        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public string FileLength { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public Stream File { get; set; }

    }
}
