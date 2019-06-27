
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


namespace AutomationSQLdm.Grooming_Modifications.TC_721965
{
   
    [TestModule("9C1E4B03-981D-4D1B-94E7-07A6171B48F1", ModuleType.UserCode, 1)]
    public class VerifyTableGrowthisAggregated :Base.BaseClass, ITestModule
    {
        
        public VerifyTableGrowthisAggregated()
        {
            // Do not delete - a parameterless constructor is required!
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
        		Steps.VerifyQueryDataCount(Config.Query_TableGrowth,"TableGrowth");
        		
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
        		Steps.VerifyQueryDataCount(Config.Query_TableGrowthAggregation,"TableGrowthAggregation");
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
