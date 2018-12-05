using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SeaBattleship.Communication.BasicTypes;

namespace SeaBattleship.Communication.CustomEventArgs
{
    public class HttpResponseCreatedEventArgs
    {
        public HttpListenerResponse Response;
        public RequestType Type;
        public string Data;
        public HttpResponseCreatedEventArgs(HttpListenerResponse response, RequestType type, string data)
        {
            Response = response;
            Type = type;
            Data = data;
        }

    }
}
