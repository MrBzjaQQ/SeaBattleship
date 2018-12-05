using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattleship.Communication;
using SeaBattleship.DatabaseWorker;

namespace SeaBattleship
{
    public class ServerModel
    {
        public ServerModel()
        {
            databaseWorker = new DatabaseWorkerModel();
            communicationModel = new CommunicationModel(databaseWorker);
        }
        public void StartServer()
        {
            communicationModel.Start();
        }
        public void StopServer()
        {
            communicationModel.Stop();
        }
        private CommunicationModel communicationModel;
        private DatabaseWorkerModel databaseWorker;
    }
    
}
