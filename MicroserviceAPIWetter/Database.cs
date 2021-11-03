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
            string insert = "INSERT INTO wetter (datum, minTemp, maxTemp, forecast, niederschlag) VALUES (@datum, @minTemp, @maxTemp, @forecast, @niederschlag)";
            DateTime datum;
            double minTemp, maxTemp;
            int forecast;
            int niederschlag;
            Random r = new Random();
            for (int i = 0; i < 7; i++) {
                double j = (double) i;
                datum = DateTime.Today.AddDays(j);
                minTemp = r.NextDouble() * (20 - 1) + 1;
                maxTemp = minTemp + 10.0;
                niederschlag = i;
                forecast = i / 3;
                connection.Execute(insert, new {
                    datum = datum,
                    minTemp = minTemp,
                    maxTemp=maxTemp,
                    forecast=forecast,
                    niederschlag = niederschlag
                });
            }

        }

        private void createTable () {
            string sql = "CREATE TABLE IF NOT EXISTS wetter (datum timestamp, minTemp numeric(5,2), maxTemp numeric(5,2), forecast numeric(5), niederschlag numeric(5,2));";
            connection.Execute(sql);
        }
    }
}
