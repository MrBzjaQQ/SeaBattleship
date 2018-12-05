using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleship.Communication.CustomEventArgs
{
    //аргументы события при получении HTTP запроса
    public class HttpRequestReceivedEventArgs : EventArgs
    {
        public HttpListenerContext Context;
        public HttpRequestReceivedEventArgs(HttpListenerContext context)
        {
            Context = context;
        }
    }
}
