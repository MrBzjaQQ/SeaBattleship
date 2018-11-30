using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWorkerModel.BasicTypes
{
    public class Hits
    {
        public int HitsID;
        public int GameID;
        public int PlayerID;
        public int XHit;
        public int YHit;
        public bool IsSuccess;
        public DateTime HitDateTime;
    }
}
