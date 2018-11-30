using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWorkerModel.BasicTypes;

namespace DatabaseWorkerModel
{
    public class DatabaseWorkerModel
    {
        public DatabaseWorkerModel()
        {
            connection = new SqlConnection(Properties.Resources.DatabaseConnectionString);
            connection.Open();
        }
        public void AddPlayer(Player player)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"EXECUTE dbo.AddPlayer {player.PlayerID}, {player.Login}, " +
                $"{player.E_Mail}, {player.Password}, {player.RegistrationDateTime.Date.ToShortDateString()}, " +
                $"{player.RegistrationDateTime.TimeOfDay.ToString("hh:mm:ss")}";
            command.ExecuteNonQuery();
        }

        public void AddPlayerField(PlayerField field)
        {
            SqlCommand command = connection.CreateCommand();
            string gameField = string.Join("", field.GameField);
            command.CommandText = $"EXECUTE dbo.AddPlayerField {field.PlayerFieldID}, " +
                $"{field.PlayerID}, {gameField}";
            command.ExecuteNonQuery();
        }

        public void AddGame(Game game)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"EXECUTE dbo.AddGame {game.GameID}, {game.HostPlayerFieldID}, " +
                $"{game.SecondPlayerFieldID}, {game.StartDateTime.Date.ToShortDateString()}, " +
                $"{game.StartDateTime.TimeOfDay.ToString("hh:mm:ss")}";
            command.ExecuteNonQuery();
        }

        public void AddHits(Hits hits)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"EXECUTE dbo.AddHits {hits.HitsID}, {hits.GameID}, {hits.PlayerID}, " +
                $"{hits.XHit}, {hits.YHit}, {Convert.ToInt16(hits.IsSuccess).ToString()}, " +
                $"{hits.HitDateTime.Date.ToShortDateString()}, {hits.HitDateTime.TimeOfDay.ToString("hh:mm:ss")}";
            command.ExecuteNonQuery();
        }

        private SqlConnection connection;
    }
}
