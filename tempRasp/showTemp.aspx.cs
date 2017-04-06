using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tempRasp
{
    public partial class showTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData obj = new GetData();
            ModelList list = new ModelList();
            list = obj.getTemp();
            DataTable dataGrid = new DataTable();
            dataGrid.Columns.Add("Date");
            dataGrid.Columns.Add("Time");
            dataGrid.Columns.Add("Sensor");
            dataGrid.Columns.Add("Temperature");
            for (int i = 0; i < list.dateList.Count; i++)
            {
                dataGrid.Rows.Add(list.dateList[i], list.timeList[i], list.sensorList[i], list.temperatureList[i]);
            }
            GridView1.DataSource = dataGrid;
            GridView1.DataBind();
        }
    }
}