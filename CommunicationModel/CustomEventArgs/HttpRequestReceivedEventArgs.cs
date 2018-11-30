using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationModel.CustomEventArgs
{
    //аргументы события при получении HTTP запроса
    public class HttpRequestReceivedEventArgs : EventArgs
    {
        public HttpListenerResponse Response;
        public HttpRequestReceivedEventArgs(HttpListenerResponse response)
        {
            Response = response;
        }
    }
}
