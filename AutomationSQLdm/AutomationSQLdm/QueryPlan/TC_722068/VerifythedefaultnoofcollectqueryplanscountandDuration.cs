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

namespace AutomationSQLdm.QueryPlan.TC_722068
{
    
    [TestModule("8FC5D361-FECC-49A0-A839-7AD6886C10A7", ModuleType.UserCode, 1)]
    public class VerifythedefaultnoofcollectqueryplanscountandDuration : Base.BaseClass,ITestModule
    {
        
        public VerifythedefaultnoofcollectqueryplanscountandDuration()
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
        		Steps.VerifyQueryPlanValue(75);
        		Steps.VerifyPlansByValue("Duration (milliseconds)");
        		Steps.ClickOnOkInMSSP();        		        		        	        
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
