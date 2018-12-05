using SeaBattleship.Communication.CustomEventArgs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleship.Communication
{
    //Класс, который отвечает за отправку сообщений клиенту
    public class Sender
    {
        public void OnRequestProcessed(object sender, HttpResponseCreatedEventArgs e)
        {
            SendResponse(e);
        }
        private void SendResponse(HttpResponseCreatedEventArgs e)
        {
            var response = e.Response;
            var data = e.Data;
            //StreamWriter writer = new StreamWriter(response.OutputStream);
            //writer.Write(data);
            //writer.Close();
            byte[] bdata = Encoding.UTF8.GetBytes(data);
            response.ContentLength64 = bdata.LongLength;
            response.OutputStream.Write(bdata, 0, bdata.Length);
        }
    }
}
