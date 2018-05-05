using CallbackContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceContract;

namespace WcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress1 = new Uri("http://localhost:10003/my");
            Uri baseAddress2 = new Uri("http://localhost:20003");
            ServiceHost mojHost1 = new ServiceHost(typeof(MojSerwis), baseAddress1);
            ServiceHost mojHost2 = new ServiceHost(typeof(mojCallbackKalkulator), baseAddress2);
            WSHttpBinding binding = new WSHttpBinding();
            WSDualHttpBinding mojBanding2 = new WSDualHttpBinding();
            try
            {
                ServiceEndpoint endpoint1 = mojHost1.AddServiceEndpoint(typeof(ISerwis), binding, "e1");
                ServiceEndpoint endpoint2 = mojHost2.AddServiceEndpoint(typeof(ICallbackKalkulator), mojBanding2, "CallbackKalkulator");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                mojHost1.Description.Behaviors.Add(smb);

                ServiceMetadataBehavior smb2 = new ServiceMetadataBehavior();
                smb2.HttpGetEnabled = true;
                mojHost2.Description.Behaviors.Add(smb2);

                mojHost1.Open();
                Console.WriteLine("--->MojSerwis jest uruchomiony.");

                mojHost2.Open();
                Console.WriteLine("--->CallbackKalkulator uruchomiony.");

                Console.WriteLine("--->Nacisnij <ENTER> aby zakonczyc.\n");
                Console.ReadLine(); //czekam na zamkniecie
                mojHost1.Close();
                mojHost2.Close();
                Console.WriteLine("---> Serwis zakonczyl dzialanie.");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystapil wyjatek: {0}", ce.Message);
                mojHost1.Abort();
                mojHost2.Abort();
            }

        }
    }
}
