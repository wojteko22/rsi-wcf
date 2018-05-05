using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CallbackContract
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICallbackHandler))]
    public interface ICallbackKalkulator
    {
        [OperationContract(IsOneWay = true)]
        void Silnia(double n);
        [OperationContract(IsOneWay = true)]
        void ObliczCos(int sek);
    }

    public interface ICallbackHandler
    {
        [OperationContract(IsOneWay = true)]
        void ZwrotSilnia(double result);
        [OperationContract(IsOneWay = true)]
        void ZwrotObliczCos(string result);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "CallbackContract.ContractType".
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
}
