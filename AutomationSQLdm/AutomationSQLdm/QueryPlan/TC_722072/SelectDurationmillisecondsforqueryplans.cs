
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

namespace AutomationSQLdm.QueryPlan.TC_722072
{
   
    [TestModule("462F0A88-1F90-46CC-A20D-50172419E9E9", ModuleType.UserCode, 1)]
    public class SelectDurationmillisecondsforqueryplans :Base.BaseClass, ITestModule
    {
        
        public SelectDurationmillisecondsforqueryplans()
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
        		Steps.ClickOnFile();
        		Steps.SelectConnectRepoOption();
        		Steps.ClickOnConnect();
        		Steps.SelectServer(Config.ServerOptions_DEFAULTSERVER);
        		Steps.ClickOnQueriesTab();
        		Steps.ClickOnSignatureMode();
        		Steps.ClickOnConfigureQueryMonitor();
        		Steps.CheckEnableQueryMonitor();
        		Steps.ClickOnExtendedEvents();
        		Steps.CheckCollectActualQueryPlans();
        		Steps.EnterTextInDurationMS(50);
        		Steps.EnterTextInQueryPlan(5);
        		Steps.SelectValueInPlansBy("Duration (milliseconds)");
        		Steps.ClickOnAdvancedTab();
        		Steps.UnCheckExcludeSQLDMQueries();
        		Steps.ClickOnOkInAQFC();
        		Steps.ClickOnOkInMSSP();
        		Steps.ClickOnWarningYes();
        		Common.WaitForSync(420000);
        		Steps.ClickOnConfigureQueryMonitor();
        		Steps.UnCheckEnableQueryMonitor();
        		Steps.ClickOnOkInMSSP();
        		Steps.VerifyQueryDataForTopQueryPlan(Config.Query_DurationMilliseconds,"DurationMilliseconds");
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
