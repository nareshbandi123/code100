using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using AutomationSQLdm.Commons;
using Ranorex;
using AutomationSQLdm.Configuration;

namespace AutomationSQLdm.Commons
{
	/// <summary>
	/// Description of SqlOperatiions.
	/// </summary>
	public class DBOperations
	{
		
		public static DataTable GetData(string sqlQuery)
        {
            //string connetionString = @"Server= CIGNITI-W12R2-1\SQL2016; Database= SQLdmRepository; Integrated Security=True";			
            string connetionString = ConfigurationManager.AppSettings["SqldmRepository"].ToString();
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                //if (con.State != ConnectionState.Open) connection.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
		
		
		public static void AddUsersToDatabase(string userType)
		{
			string userToAdd = string.Empty;
			int result=0; string sqlCreateLogin = string.Empty;
			SqlCommand cmd = null;
			//string databasename = "SQLdmRepository";
			
			if(userType.ToLower().Equals(Config.NewSqlUser.ToLower()))
	        {
				userToAdd = Config.NewSqlUser;
	        	sqlCreateLogin = "CREATE LOGIN " + userToAdd + " WITH PASSWORD = '" +
	            Config.NewSqlUserPassword + "';  USE " + Config.RepositoryName + "; CREATE USER " + userToAdd + " FOR LOGIN " + userToAdd + ";";
	        }
	        else
	        {
	        	userToAdd = Config.NewWindowsUser;
	        	sqlCreateLogin = "CREATE LOGIN [" + userToAdd + "] FROM WINDOWS;" +
	            "USE " + Config.RepositoryName + "; CREATE USER [" + userToAdd + "] FOR LOGIN [" + userToAdd + "];";
	        	//CREATE LOGIN [SIMPSONS\administrator1] FROM WINDOWS;USE SQLdmRepository; CREATE USER [SIMPSONS\administrator1] FOR LOGIN [SIMPSONS\administrator1];
	        }
	        
			Report.Info(userToAdd);
		    string connetionString = ConfigurationManager.AppSettings["SqldmRepositoryConn"].ToString();
            using (SqlConnection conn = new SqlConnection(connetionString))
            {
		        conn.Open();
				
		        string sqlLoginChk = "USE " + Config.RepositoryName + "; select count(*) from master.dbo.syslogins where name ='"+ userToAdd +"'";
		        cmd = new SqlCommand(sqlLoginChk,conn);
		        result = Convert.ToInt16(cmd.ExecuteScalar());
		        
		        
		        if(result>=1) // User already Exists
		        {
		        	string sqlDropLoginAndUser = "drop login ["+userToAdd +"];USE " + Config.RepositoryName + ";drop user ["+ userToAdd +"];";
		        	cmd = new SqlCommand(sqlDropLoginAndUser,conn);
			        int resultDropLogin = cmd.ExecuteNonQuery();
			        //if(resultDropLogin >=1)
				    Reports.ReportLog("Login and User '"+ userToAdd +"' dropped from SSMS", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//		        	else
//		        		Reports.ReportLog("Login and User "+ userToAdd +" both are failed to be dropped from SSMS", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
		        }
		        
		        cmd = new SqlCommand(sqlCreateLogin,conn);
		        cmd.ExecuteNonQuery();
				Reports.ReportLog("User "+ userToAdd +" added to SSMS", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					
//		        if(result<1)
//		        {
//			        cmd = new SqlCommand(sqlCreateLogin,conn);
//			        cmd.ExecuteNonQuery();
//					Reports.ReportLog("User "+ userToAdd +" added to SSMS", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//		        }
//		        else
//		        {
//		        	Reports.ReportLog("User "+ userToAdd +" already exists in SSMS", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
//		        }
		
      			cmd.Dispose();
		        conn.Close();
		    }
		}
		
//		static SqlConnection connection = null;
//        static SqlCommand command = null;
//        static SqlDataReader dataReader = null;
//
//        public static void ExecuteQuery(string sqlServer, string sqlQuery, string getOnlySchema = "")
//        {
//            string connetionString = null;
//            int wait = 0, maxWait = 180000;
//            //connetionString = "Data Source=AUT-SQLDM-006;Initial Catalog=SQLdmRepository;Integrated Security=true";
//            connetionString = "Data Source="+ sqlServer + ";Initial Catalog=SQLdmRepository;Integrated Security=true";
//            // sqlQuery = "select * from ActiveWaitStatistics";
//            connection = new SqlConnection(connetionString);
//            try
//            {
//                if (connection.State != ConnectionState.Open) connection.Open();
//                command = new SqlCommand(sqlQuery, connection);
//                dataReader = command.ExecuteReader();
//                if (getOnlySchema == "")
//                {
//                    if (!dataReader.HasRows)
//                    {
//                        System.Threading.Thread.Sleep(20000); // Delay for 20 sec
//                        if (wait <= maxWait)  // maxWait for 3 minutes
//                        {
//                            ExecuteQuery(sqlServer, sqlQuery);
//                            wait = wait + 20000;
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//               
//            }
//        }
//        
//        public static void VerifyQueryResult(string sqlServer, string sqlQuery)
//        {
//            try
//            {
//                ExecuteQuery(sqlServer, sqlQuery);
//                if (dataReader.HasRows)
//                {
//                    // Write validation logic here..also can write code for iterating over dataReader if require to validate some specific data 
//                    // Validate.AttributeEqual(repo.ElementInfo, "InnerText", "", null, false);
//                    // Report.Log(ReportLevel.Info,"");  
//                }
//                else
//                {
//                    // Validation Failed - TC failed 
//                }
//                dataReader.Close();
//                command.Dispose();
//                connection.Close();
//            }
//            catch (Exception ex)
//            {
//                dataReader.Close();
//                command.Dispose();
//                connection.Close();
//            }
//        }
//		
//        public static void VerifyTableSchema(string sqlServer, string sqlQuery, string tableColumnsToVerify)
//        {
//            DataTable schemaTable; string[] arrColumnsToVerify = null; bool chkExistance = true;
//            try
//            {
//                ExecuteQuery(sqlServer, sqlQuery, "schema");
//                //Retrieve column schema into a DataTable.
//                schemaTable = dataReader.GetSchemaTable();
//
//                if (tableColumnsToVerify.Contains(","))
//                {
//                    arrColumnsToVerify = tableColumnsToVerify.Split(',');
//
//                    foreach (string column in arrColumnsToVerify)
//                    {
//                        if (!schemaTable.Columns.Contains(column))
//                        {
//                            chkExistance = false;
//                            break;
//                        }
//                    }
//                }
//                else
//                {
//                    if(!schemaTable.Columns.Contains(tableColumnsToVerify))
//                    {
//                        chkExistance = false;
//                    }
//                }
//
//                if (chkExistance == false)
//                {
//                    // Validation Failed - TC failed 
//                }
//                else
//                    // Validation Passed - TC Passed 
//
//                dataReader.Close();
//                command.Dispose();
//                connection.Close();
//            }
//            catch (Exception ex)
//            {
//                dataReader.Close();
//                command.Dispose();
//                connection.Close();
//            }
//        }

		
	}
}
