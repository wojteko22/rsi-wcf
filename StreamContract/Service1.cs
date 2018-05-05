using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StreamContract
{
    public class MojStrumien : IStrumien {
        public System.IO.Stream getStream(string data) {
            FileStream myFile;
            Console.WriteLine("-->Wywolano getStream");
            string filePath = Path.Combine(System.Environment.CurrentDirectory, ".\\image.jpg");
            // wyjatek na wypadek bledu otwarcia pliku
            try {
                myFile = File.OpenRead(filePath);
            }
            catch (IOException ex) {
                Console.WriteLine(String.Format("Wyjatek otwarcia pliku {0} :", filePath));
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            return myFile;
        }

        public ResponseFileMessage getMStream(RequestFileMessage request)
        {
            ResponseFileMessage wynik = new ResponseFileMessage();
            string nazwa = request.nazwa1;

            FileStream myFile;
            Console.WriteLine("-->Wywolano getStream");
            string filePath = Path.Combine(System.Environment.CurrentDirectory, ".\\" + nazwa);
            // wyjatek na wypadek bledu otwarcia pliku
            try
            {
                myFile = File.OpenRead(filePath);
            }
            catch (IOException ex)
            {
                Console.WriteLine(String.Format("Wyjatek otwarcia pliku {0} :", filePath));
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            wynik.nazwa2 = "amazing_name.jpg";
            wynik.rozmiar = myFile.Length;
            wynik.dane = myFile;
            return wynik;
        }
    }
}
