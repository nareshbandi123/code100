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


namespace AutomationSQLdm.Grooming_Modifications.TC_721963
{
  
    [TestModule("E50F231C-C1A4-4F2C-BD07-B4C434A30121", ModuleType.UserCode, 1)]
    public class VerifyDBSizeDateTimeAggregated :Base.BaseClass, ITestModule
    {
       
        public VerifyDBSizeDateTimeAggregated()
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
        		Steps.VerifyQueryDataCount(Config.Query_DBSizeDateTime,"DatabaseSizeDateTime");
        		
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
        		Steps.VerifyQueryDataCount(Config.Query_DBSizeDateTimeAggregation,"DatabaseSizeDateTimeAggregation");
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
