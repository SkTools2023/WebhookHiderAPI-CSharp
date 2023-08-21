using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Template_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your api code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter your message: ");
            string message = Console.ReadLine();
            string postData = "code=" + Uri.EscapeDataString(code) + "&message=" + Uri.EscapeDataString(message);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sktools.sytes.net/webhookhider/API");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.AllowWriteStreamBuffering = false;

            using (Stream requestStream = request.GetRequestStream())
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(postData);
                requestStream.Write(dataBytes, 0, dataBytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                string responseString = reader.ReadToEnd();
                Console.WriteLine("Response: " + responseString);
                Thread.Sleep(5000);

            }
        }
    }
}
