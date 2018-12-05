using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattleship.DatabaseWorker;

namespace SeaBattleship.Communication
{
    //модель должна быть максимально простой.
    //есть слушатель, который получает пакет и через событие возвращает запрос
    //есть обработчик, который рассматривает текущий запрос, и преобразует его из HTTP запроса в нечто понятное модели
    //есть отправитель, который выбирает тип ответа и отправляет соответствующий ответ
    public class CommunicationModel
    {
        public CommunicationModel(DatabaseWorkerModel database)
        {
            databaseWorker = database;
            listener = new Listener();
            handler = new MessageHandler(databaseWorker);
            sender = new Sender();
            listener.RequestReceived += handler.OnRequestReceived;
            handler.RequestProcessed += sender.OnRequestProcessed;
        }
        
        public void Start()
        {
            listener.Start();
        }

        public void Stop()
        {
            listener.Stop();
        }
        private Listener listener;
        private MessageHandler handler;
        private Sender sender;
        private DatabaseWorkerModel databaseWorker;
    }
}
