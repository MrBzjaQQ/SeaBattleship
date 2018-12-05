using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleship.DatabaseWorker.BasicTypes
{
    public class Game
    {
        public int GameID;
        public int HostPlayerFieldID;
        public int SecondPlayerFieldID;
        public DateTime StartDateTime;
    }
}
