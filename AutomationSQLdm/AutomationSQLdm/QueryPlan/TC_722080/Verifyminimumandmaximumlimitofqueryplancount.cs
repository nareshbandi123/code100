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

namespace AutomationSQLdm.QueryPlan.TC_722080
{
    
    [TestModule("DD52EAE5-20FD-49F7-91B6-A544B55133D1", ModuleType.UserCode, 1)]
    public class Verifyminimumandmaximumlimitofqueryplancount :Base.BaseClass, ITestModule
    {        
        public Verifyminimumandmaximumlimitofqueryplancount()
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
        	    Steps.SelectServer(Config.ServerOptions_DEFAULTSERVER); //Version 2016
        		Steps.ClickOnQueriesTab();
        		Steps.ClickOnSignatureMode();
        		Steps.ClickOnConfigureQueryMonitor();
        		Steps.CheckEnableQueryMonitor();
        		Steps.VerifyQueryPlanOptionsEnable();
        		Steps.EnterTextInQueryPlan(0);
        		Steps.ClickOnOkInMSSP();
        		Steps.ClickOnConfigureQueryMonitor();
        		Steps.VerifyQueryPlanValue(1);        		
        		Steps.EnterTextInQueryPlan(1002);
        		Steps.ClickOnOkInMSSP();
        		Steps.ClickOnConfigureQueryMonitor();
        		Steps.VerifyQueryPlanValue(1000);
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
