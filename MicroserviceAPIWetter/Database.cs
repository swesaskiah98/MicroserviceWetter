using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using MicroserviceAPIWetter.Model;

namespace MicroserviceAPIWetter {
    public class Database {
        private NpgsqlConnection connection;
        private string connectionString;

        public void createDatabase () {
            openConnection();
            createTable();
            createDemoData();
            connection.Close();
        }

        public List<WetterData> getData () {
            openConnection();
            string getData = "SELECT * FROM wetter;";
            var data=connection.Query<WetterData>(getData);
            List<WetterData> dataList = data as List<WetterData>;
            return dataList;
        }

        public void openConnection () {
            connectionString = "Host=" + ConfigurationManager.AppSettings.Get("Host") + "; Port=" + ConfigurationManager.AppSettings.Get("Port") + "; Username="
                + ConfigurationManager.AppSettings.Get("Username") + "; Password=" + ConfigurationManager.AppSettings.Get("Password") + "; Database=" +
                ConfigurationManager.AppSettings.Get("Database") + ";";
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        private void createDemoData () {
            //ToDo insert into if not exists statt delete verwenden, oder flag in App.config?
            string delete = "DELETE FROM wetter;";
            connection.Execute(delete);
            string insert = "INSERT INTO wetter (datum, temperatur, niederschlag) VALUES (@datum, @temperatur, @niederschlag)";
            DateTime datum;
            double temperatur;
            bool niederschlag = false;
            Random r = new Random();
            for (int i = 0; i < 7; i++) {
                double j = (double) i;
                datum = DateTime.Today.AddDays(j);
                temperatur = r.NextDouble() * (30 - 1) + 1;
                niederschlag = niederschlag==false ? true : false;
                connection.Execute(insert, new {
                    datum = datum,
                    temperatur = temperatur,
                    niederschlag = niederschlag
                });
            }

        }

        private void createTable () {
            string sql = "CREATE TABLE IF NOT EXISTS wetter (datum timestamp, temperatur numeric(5,2), niederschlag boolean);";
            connection.Execute(sql);
        }
    }
}
