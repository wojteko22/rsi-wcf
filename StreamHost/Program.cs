using StreamContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace StreamHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:50000/");
            ServiceHost mojHost = new ServiceHost(typeof(MojStrumien), baseAddress);

            BasicHttpBinding b = new BasicHttpBinding();
            b.TransferMode = TransferMode.Streamed;
            b.MaxReceivedMessageSize = 1000000000;
            b.MaxBufferSize = 8192;
            ServiceEndpoint endpoint = mojHost.AddServiceEndpoint(typeof(IStrumien), b, baseAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            mojHost.Description.Behaviors.Add(smb);

            mojHost.Open();
            Console.WriteLine("--->MojStrumien uruchomiony.");
            Console.WriteLine("--->Nacisnij <ENTER> aby zakonczyc.\n");
            Console.ReadLine(); //czekam na zamkniecie
            mojHost.Close();
            Console.WriteLine("---> Serwis zakonczyl dzialanie.");
        }
    }
}