using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommunicationModel.CustomEventArgs;

namespace CommunicationModel
{
    //класс, который принимает входящие запросы
    public class Listener
    {
        public EventHandler<HttpRequestReceivedEventArgs> RequestReceived;
        public Listener()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(Properties.Resources.ConnectionPrefix);
        }
        public void Start()
        {
            _listening = new Thread(() =>
            {
                while (true)
                {
                    _listener.Start();
                    HttpListenerContext context = _listener.GetContext();
                    RequestReceived.Invoke(this, new HttpRequestReceivedEventArgs(context.Response));
                }
            });
            _listening.Start();
        }
        public void Stop()
        {
            if (_listening.IsAlive)
                _listening.Interrupt();
        }
        private Thread _listening;
        private HttpListener _listener;
    }
}
