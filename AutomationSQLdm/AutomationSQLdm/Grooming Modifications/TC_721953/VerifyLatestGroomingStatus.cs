
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
using AutomationSQLdm.Configuration;
using AutomationSQLdm.DataBaseOperations;
using AutomationSQLdm.Commons;

namespace AutomationSQLdm.Grooming_Modifications.C_T721953
{
   
    [TestModule("5D89291D-83E8-4A7C-B6BA-DB62CA18C04D", ModuleType.UserCode, 1)]
    public class VerifyLatestGroomingStatus : ITestModule
    {
        
        public VerifyLatestGroomingStatus()
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
        		
        		//Verify LatestGroomingStatus Table Info in DB
	            string queryLatestGroomingStatus = "Select * from dbo.LatestGroomingStatus";
	        	DataTable dtLatestGroomingStatus = DataAccess.GetData(queryLatestGroomingStatus);
	        	if(dtLatestGroomingStatus != null && dtLatestGroomingStatus.Rows.Count > 0)
	        	{
	      			Reports.ReportLog("No Of Records Present in LatestGrooming Status Is : " + dtLatestGroomingStatus.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        	}
	        	else
	        	{
	        		Reports.ReportLog("Records are not Present in LatestGrooming Status", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        		
	        	}
	        	
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.ClickOnGroomNow();
        		
        		//Verify LatestGroomingStatus After Grooming Table Info in DB
	            string queryLatestGroomingStatusAfter = "Select * from dbo.LatestGroomingStatus";
	        	DataTable dtLatestGroomingStatusAfter = DataAccess.GetData(queryLatestGroomingStatusAfter);
	        	if(dtLatestGroomingStatusAfter != null && dtLatestGroomingStatusAfter.Rows.Count > 0)
	        	{
	      			Reports.ReportLog("No Of Records Present in LatestGrooming Status After Grooming Is : " + dtLatestGroomingStatusAfter.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
	        	}
	        	else
	        	{
	        		Reports.ReportLog("Records are not Present in LatestGrooming Status After Groom", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
	        		
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
