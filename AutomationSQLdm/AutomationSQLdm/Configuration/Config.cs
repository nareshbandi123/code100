
using System;
using System.Configuration;

namespace AutomationSQLdm.Configuration
{
 
    public static class Config 
    {
        public static string AppPath = ConfigurationManager.AppSettings["APP_PATH"].ToString();
        
        public static string NewWindowsUser = ConfigurationManager.AppSettings["NewWindowsUser"].ToString();
		public static string NewSqlUser = ConfigurationManager.AppSettings["NewSqlUser"].ToString();
		public static string NewSqlUserPassword = ConfigurationManager.AppSettings["NewSqlUserPassword"].ToString();
		
		public static string SqlSystemUser = ConfigurationManager.AppSettings["SqlSystemUser"].ToString();
		public static string SqlSystemUserPassword = ConfigurationManager.AppSettings["SqlSystemUserPassword"].ToString();
		
//		public static string SQLdmRepository = ConfigurationManager.AppSettings["SQLdmRepository"].ToString();
		public static string RepositoryName = ConfigurationManager.AppSettings["RepositoryName"].ToString();
		
		
		public static int ProcessID;
		public static string TestCaseName;
		
		
		//Available Servers
		//public const string ServerOptions_DEFAULTSERVER 	= "CMWIN2016-S8";  //ForNavigations
		//public const string ServerOptions_SQLAUTHSERVER 	= "T-MSSQL2016";  //ForSQLAuthentication
		public const string ServerOptions_CMWIN2016S8 		= "CMWIN2016-S8";
		public const string ServerOptions_CMWIN2016SQL17 	= "CMWIN2016SQL17";
		public const string ServerOptions_TMSSQL2016 		= "T-MSSQL2016";
		public const string ServerOptions_FORDELETE 		= "BI-ET-W2012";  //ForDeleteServer
		//public const string ServerOptions_DEFAULTSERVER 	= "T-MSSQL2016";  //ForNavigations
		public const string ServerOptions_DEFAULTSERVER 	= @"WIN2016\SQL2017";  //ForNavigations
		public const string ServerOptions_SQLAUTHSERVER 	= @"WIN2016\SQL2017";  //ForSQLAuthentication
		
		//Available Queryyes
		public const string Query_DBFileStatistics 			= "Select * from DatabaseFileStatistics";
		public const string Query_DBSize		   			= "Select * from DatabaseSize";
		public const string Query_DBSizeDateTime   			= "Select * from DatabaseSizeDateTime";
		public const string Query_DiskDriveStatistics  		= "Select * from DiskDriveStatistics";
		public const string Query_TableGrowth   			= "Select * from TableGrowth";
		public const string Query_MonitoredSQLServers   	= "Select * from MonitoredSQLServers";
		public const string Query_AnalysisConfiguration   	= "Select * from AnalysisConfiguration";
		
		
		public const string Query_DBFileStatisticsAggregation 		= "Select * from DatabaseFileStatisticsAggregation";
		public const string Query_DBSizeAggregation		   			= "Select * from DatabaseSizeAggregation";
		public const string Query_DBSizeDateTimeAggregation   		= "Select * from DatabaseSizeDateTimeAggregation";
		public const string Query_DiskDriveStatisticsAggregation	= "Select * from DiskDriveStatisticsAggregation";
		public const string Query_TableGrowthAggregation 			= "Select * from TableGrowthAggregation";
		
		//Available Queryyes for Top Query Plans
		//delete from QueryMonitorStatistics
		public const string Query_DurationMilliseconds		= "select PlanID from QueryMonitorStatistics where SQLServerID = '4' and PlanID is not null order by DurationMilliseconds DESC";
		public const string Query_LogicalDiskReads 			= "select PlanID from QueryMonitorStatistics where SQLServerID = '4' and PlanID is not null order by Reads DESC";
		public const string Query_CPUUsage 					= "select PlanID from QueryMonitorStatistics where SQLServerID = '4' and PlanID is not null order by CPUMilliseconds DESC";
		public const string Query_PhysicalDiskWrites		= "select PlanID from QueryMonitorStatistics where SQLServerID = '4' and PlanID is not null order by Writes DESC";
		
		
		public static string WindowsUser = ConfigurationManager.AppSettings["WindowsUser"].ToString();
		public static string WinUserPassword = ConfigurationManager.AppSettings["WinUserPassword"].ToString();
		
		
    }
}
