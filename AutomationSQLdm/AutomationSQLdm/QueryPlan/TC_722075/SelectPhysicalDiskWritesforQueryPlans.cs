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

namespace AutomationSQLdm.QueryPlan.TC_722075
{
    
    [TestModule("EF4D3ABB-CACB-48A0-AA06-E71701BB72F8", ModuleType.UserCode, 1)]
    public class SelectPhysicalDiskWritesforQueryPlans :Base.BaseClass, ITestModule
    {
       
        public SelectPhysicalDiskWritesforQueryPlans()
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
        		Steps.SelectValueInPlansBy("Physical disk writes");
        		Steps.ClickOnAdvancedTab();
        		Steps.UnCheckExcludeSQLDMQueries();
        		Steps.ClickOnOkInAQFC();
        		Steps.ClickOnOkInMSSP();
        		Steps.ClickOnWarningYes();
        		Common.WaitForSync(420000);
        		Steps.ClickOnConfigureQueryMonitor();
        		Steps.UnCheckEnableQueryMonitor();
        		Steps.ClickOnOkInMSSP();
        		Steps.VerifyQueryDataForTopQueryPlan(Config.Query_PhysicalDiskWrites,"PhysicalDiskWrites");
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
