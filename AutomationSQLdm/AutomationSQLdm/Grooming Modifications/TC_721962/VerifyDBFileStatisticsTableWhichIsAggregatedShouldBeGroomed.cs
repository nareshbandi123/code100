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

namespace AutomationSQLdm.Grooming_Modifications.TC_721962
{
    
    [TestModule("C942496D-68D8-453F-B3EA-A7EA8456E675", ModuleType.UserCode, 1)]
    public class VerifyDBFileStatisticsTableWhichIsAggregatedShouldBeGroomed :Base.BaseClass, ITestModule
    {
        
        public VerifyDBFileStatisticsTableWhichIsAggregatedShouldBeGroomed()
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
        		int Aggregation 				= 2;
        		string BeforeRunningStatus 		= "Yes";
        		string AfterRunningStatus 		= "No";
        		string CompletionStatus 		= "Succeeded";	
        		string CurrentRunningStatusInDG = "Yes";
        		string CurrentRunningStatusAfterInDG = "No";
        		string CompletionStatusInDG		 = "Succeeded";
        			
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.EnterTextInAggregateForecasting(Aggregation);
        		Steps.ClickOnOk();
        		Steps.VerifyQueryDataCount(Config.Query_DBFileStatistics,"DatabaseFileStatistics");
        		
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
        		Steps.VerifyQueryDataCount(Config.Query_DBFileStatisticsAggregation,"DatabaseFileStatisticsAggregation");
        		
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.ClickOnGroomNow();
        		Steps.VerifyCurrentRunningStatusInDataGrooming(CurrentRunningStatusInDG);
        		Steps.ClickOnOk();
        		
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.VerifyCurrentRunningStatusInDataGrooming(CurrentRunningStatusAfterInDG);
        		Steps.VerifyCompletionStatusInDataGrooming(CompletionStatusInDG);
        		Steps.ClickOnOk();
        		Steps.VerifyQueryDataCount(Config.Query_DBFileStatistics,"DatabaseFileStatistics");
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
