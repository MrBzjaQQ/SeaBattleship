using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SeaBattleship.Communication.CustomEventArgs;
using SeaBattleship.DatabaseWorker;

namespace SeaBattleship.Communication
{
    //Класс, который отвечает за обработку сообщений
    public class MessageHandler
    {
        public MessageHandler(DatabaseWorkerModel database)
        {
            databaseWorker = database;
        }
        public EventHandler<HttpResponseCreatedEventArgs> RequestProcessed;
        public void OnRequestReceived(object sender, HttpRequestReceivedEventArgs e)
        {
            var context = e.Context;
            ProcessMessage(context);
        }

        private void ProcessMessage(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;
            switch (request.RawUrl)
            {
                case "/signin":
                    {
                        response.StatusCode = 200;
                        StreamReader reader = new StreamReader(request.InputStream);
                        string requestBody = reader.ReadToEnd(); //TODO написать нормальный парсер
                        string[] parameters = requestBody.Replace("{", "").Replace("}", "").Split(',');
                        //string login = parameters[0].Trim(' ', '\n', '\t').Replace("\"login\": ", "").Replace("\"", "");
                        //string password = parameters[1].Trim(' ', '\n', '\t').Replace("\"password\": ", "").Replace("\"", "");
                        string login = "a@z.com";
                        string password = "lollol";
                        string data = databaseWorker.CheckLogIn(login, password);
                        if (string.IsNullOrEmpty(data))
                            data = "{ \"success\": false,\n\"error\": \"Invalid credentials\" }";
                        else
                            data = "{\n\"success\": true,\n" + data + "}";
                        RequestProcessed.Invoke(this, new HttpResponseCreatedEventArgs(response, BasicTypes.RequestType.Signin, data)); //TODO Нужен ли тип запроса?
                        break;
                    }
                default:
                    {
                        response.StatusCode = 200;
                        string data = string.Empty;
                        RequestProcessed.Invoke(this, new HttpResponseCreatedEventArgs(response, BasicTypes.RequestType.Undefined, data));
                        break;
                    }
            }

        }
        private DatabaseWorkerModel databaseWorker;
    }
}
