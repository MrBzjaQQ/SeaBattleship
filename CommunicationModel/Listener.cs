using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeaBattleship.Communication.CustomEventArgs;

namespace SeaBattleship.Communication
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
                    HttpListenerContext context = _listener.GetContext(); //для работы с SocketIO использовать RawUrl
                    RequestReceived.Invoke(this, new HttpRequestReceivedEventArgs(context));
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
