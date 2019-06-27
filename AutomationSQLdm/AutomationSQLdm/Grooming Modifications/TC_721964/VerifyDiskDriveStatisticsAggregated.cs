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
using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;


namespace AutomationSQLdm.Grooming_Modifications.TC_721964
{
   
    [TestModule("054AFDB7-5E9B-43A7-BC0E-EAAD7DD715F2", ModuleType.UserCode, 1)]
    public class VerifyDiskDriveStatisticsAggregated :Base.BaseClass, ITestModule
    {
        
        public VerifyDiskDriveStatisticsAggregated()
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
        		int Aggregation = 2;
        		string BeforeRunningStatus = "Yes";
        		string AfterRunningStatus = "No";
        		string CompletionStatus = "Succeeded";	
        		
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.EnterTextInAggregateForecasting(Aggregation);
        		Steps.ClickOnOk();
        		Steps.VerifyQueryDataCount(Config.Query_DiskDriveStatistics,"DiskDriveStatistics");
        		
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.ClickOnAggregateNow();
        		Steps.VerifyCurrentRunningStatusInAggregation(BeforeRunningStatus);
        		Steps.ClickOnOk();
        		
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.VerifyCurrentRunningStatusInAggregation(AfterRunningStatus);
        		Steps.VerifyCompletionStatusInAggregation(CompletionStatus);
        		Steps.ClickOnOk();
        		Steps.VerifyQueryDataCount(Config.Query_DiskDriveStatisticsAggregation,"DiskDriveStatisticsAggregation");
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
