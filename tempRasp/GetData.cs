using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace tempRasp
{

    public class ModelList
    {
        public List<string> dateList = new List<string>();
        public List<string> timeList = new List<string>();
        public List<string> sensorList = new List<string>();
        public List<string> temperatureList = new List<string>();
    }

    public class GetData
    {
        public ModelList getTemp()
        {
            ModelList list = new ModelList();
            try
            {
                string connectionString = "Server=192.168.1.19;Database=tempSensor1;Port=3306;User ID=root4;Password=1234";  // credentials
                MySqlConnection conDB = new MySqlConnection(connectionString);
                conDB.Open();
                Console.WriteLine("Connect");
                string query = "SELECT * FROM dataSensor1";
                MySqlCommand cmd = new MySqlCommand(query, conDB);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list.dateList.Add(dataReader["tdate"] + "");
                    list.timeList.Add(dataReader["ttime"] + "");
                    list.sensorList.Add(dataReader["sensor"] + "");
                    list.temperatureList.Add(dataReader["temperature"] + "");
                }
                dataReader.Close();
                conDB.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }
}