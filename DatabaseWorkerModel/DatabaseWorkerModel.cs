using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattleship.DatabaseWorker.BasicTypes;

namespace SeaBattleship.DatabaseWorker
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

        public string CheckLogIn(string eMail, string password)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"USE [SeaBattleshipDatabase]; SELECT * FROM Player WHERE [E-mail] = \'{eMail}\' AND Password = \'{password}\'";
            using (var dataReader = command.ExecuteReader())
            {
                if (!dataReader.HasRows)
                    return string.Empty;
                dataReader.Read();
                Player player = new Player();
                player.PlayerID = Int32.Parse(dataReader.GetValue(0).ToString());
                player.Login = dataReader.GetValue(1).ToString();
                player.Nickname = dataReader.GetValue(2).ToString();
                player.FirstName = dataReader.GetValue(3).ToString();
                player.LastName = dataReader.GetValue(4).ToString();
                player.E_Mail = dataReader.GetValue(5).ToString();
                player.Password = dataReader.GetValue(6).ToString();
                string data = "\"data\": {\n" +
                    $"\"id\": \"{Guid.NewGuid()}\",\n" +
                    $"\"login\": \"{player.E_Mail}\",\n" +
                    $"\"nickname\": \"{player.Nickname}\",\n" +
                    $"\"firstname\": \"{player.FirstName}\",\n" +
                    $"\"lastname\": \"{player.LastName}\",\n" +
                    $"\"token\": \"{Guid.NewGuid()}\"" +
                    "}\n";
                return data;
            }
        }
        private SqlConnection connection;
    }
}
