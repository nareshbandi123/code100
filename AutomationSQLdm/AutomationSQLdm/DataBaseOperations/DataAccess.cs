using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

namespace AutomationSQLdm.DataBaseOperations
{
    
    public static class DataAccess
	{
		//string connetionString = System.Configuration.ConfigurationManager.AppSettings["SERVER_001"].ToString();
		public static string connetionString = System.Configuration.ConfigurationManager.AppSettings["SERVER_002"].ToString();
		public static DataTable GetData(string sqlQuery)
        {
        	DataTable resultTable = null;  
            using(SqlConnection connection = new SqlConnection(connetionString))
            {
            	connection.Open();
            	SqlCommand command = new SqlCommand(sqlQuery, connection);
            	SqlDataAdapter adapter = new SqlDataAdapter(command);  
            	resultTable = new DataTable();
    			adapter.Fill(resultTable);  
            }
            return resultTable;
        }
	}
}
