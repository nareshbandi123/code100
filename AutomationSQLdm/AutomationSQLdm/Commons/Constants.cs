using System;

namespace AutomationSQLdm.Commons
{
	/// <summary>
	/// Description of DBConstants.
	/// </summary>
	public class Constants
	{
		
		public  static string[] RepositoryInfo_TableCols = { "GroomMetrics", "GroomAlerts", "GroomQueryAggregation", "GroomPrescriptiveAnalysis","AggregateForecasting","GroomForecasting"};
		public const string RepositoryInfo_ColName = "Internal_Value";
		public const string WindowsUser = "WindowsUser";
		public const string SqlUser = "SqlUser";
		public const string strAdministrator = "Administrator";
		//{"GroomForecasting", "AggregateForecasting", "GroomPrescriptiveAnalysis","GroomQueryAggregation","GroomAlerts","GroomMetrics"};

#region SQLDM Constants
				
		
//		public const string NewWindowsUser = @"SIMPSONS\administrator1";
//		public const string NewSqlUser = @"sa1";
//		public const string NewSqlUserPassword = @"Admin@123";
//		
//		public const string SqlSystemUser = @"sa";
//		public const string SqlSystemUserPassword = @"Admin@123";
//		
//		public const string SQLdmRepository = @"SQLdmRepository";
		public const string tagSnoozeAlert = "TagSnoozeAlert";
		public const string allServer = "AllServer";
#endregion
	}
}
