using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using AutomationSQLdm.Commons;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using AutomationSQLdm.Configuration;
using AutomationSQLdm.DataBaseOperations;

namespace AutomationSQLdm.Grooming_Modifications.TC_721950
{
   
    [TestModule("D7947544-DB38-45BE-B72B-1D7F8A7CB391", ModuleType.UserCode, 1)]
    public class VerifyThreeMetrics :Base.BaseClass, ITestModule
    {
        
        public VerifyThreeMetrics()
        {
            
        }

         void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		
        		//Verify DatabaseFileStatistics Table Info in DB
	            string queryDatabaseFileStatistics = "Select * from DatabaseFileStatistics";
	        	DataTable dtDatabaseFileStatistics = DataAccess.GetData(queryDatabaseFileStatistics);
	        	if(dtDatabaseFileStatistics != null && dtDatabaseFileStatistics.Rows.Count > 0)
	        	{
	      			Reports.ReportLog("DatabaseFileStatistics Table Is Present", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        		Reports.ReportLog("Records present in DatabaseFileStatistics Is : " + dtDatabaseFileStatistics.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        	}
	        	else
	        	{
	        		Reports.ReportLog("DatabaseFileStatistics Table Is Not Present", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        		Reports.ReportLog("Records is not present in DatabaseFileStatistics " , Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        	}

	        	//Verify DatabaseSize Table Info in DB
	            string queryDatabaseSize = "Select * from DatabaseSize";
	        	DataTable dtDatabaseSize = DataAccess.GetData(queryDatabaseSize);
	        	if(dtDatabaseSize != null && dtDatabaseSize.Rows.Count > 0)
	        	{
	      			Reports.ReportLog("DatabaseSize Table Is Present", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        		Reports.ReportLog("Records present in DatabaseSize Is : " + dtDatabaseSize.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        	}
	        	else
	        	{
	        		Reports.ReportLog("DatabaseSize Table Is Not Present", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        		Reports.ReportLog("Records is not present in DatabaseSize " , Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        	}
	        		
	        	//Verify DatabaseSizeDateTime Table Info in DB
	            string queryDatabaseSizeDateTime = "Select * from DatabaseSizeDateTime";
	        	DataTable dtDatabaseSizeDateTime = DataAccess.GetData(queryDatabaseSizeDateTime);
	        	if(dtDatabaseSizeDateTime != null && dtDatabaseSizeDateTime.Rows.Count > 0)
	        	{
	      			Reports.ReportLog("DatabaseSizeDateTime Table Is Present", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        		Reports.ReportLog("Records present in DatabaseSizeDateTime Is : " + dtDatabaseSizeDateTime.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        	}
	        	else
	        	{
	        		Reports.ReportLog("DatabaseSizeDateTime Table Is Not Present", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        		Reports.ReportLog("Records is not present in DatabaseSizeDateTime " , Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        	}
	        	
	        	//Verify DiskDriveStatistics Table Info in DB
	            string queryDiskDriveStatistics = "Select * from DiskDriveStatistics";
	        	DataTable dtDiskDriveStatistics = DataAccess.GetData(queryDiskDriveStatistics);
	        	if(dtDiskDriveStatistics != null && dtDiskDriveStatistics.Rows.Count > 0)
	        	{
	      			Reports.ReportLog("DiskDriveStatistics Table Is Present", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        		Reports.ReportLog("Records present in DiskDriveStatistics Is : " + dtDiskDriveStatistics.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        	}
	        	else
	        	{
	        		Reports.ReportLog("DiskDriveStatistics Table Is Not Present", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        		Reports.ReportLog("Records is not present in DiskDriveStatistics " , Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        	}
	        		
	        	//Verify TableGrowth Table Info in DB
	            string queryTableGrowth = "Select * from TableGrowth";
	        	DataTable dtTableGrowth = DataAccess.GetData(queryTableGrowth);
	        	if(dtTableGrowth != null && dtTableGrowth.Rows.Count > 0)
	        	{
	      			Reports.ReportLog("TableGrowth Table Is Present", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        		Reports.ReportLog("Records present in TableGrowth Is : " + dtTableGrowth.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        	}
	        	else
	        	{
	        		Reports.ReportLog("TableGrowth Table Is Not Present", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        		Reports.ReportLog("Records is not present in TableGrowth " , Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        	}
	        	Common.UpdateStatus(1); // 1 : Pass
	        		
        	} 
        	catch (Exception ex)
        	{
        		Common.UpdateStatus(5); // 5 : fail
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
    }
}
