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

namespace AutomationSQLdm.QueryPlan.TC_722077
{
   
    [TestModule("78BCEA02-5B2E-4887-8150-3E4C0A218F5F", ModuleType.UserCode, 1)]
    public class Verifyqueryplancountandselecttopoptionsarenotenabled :Base.BaseClass, ITestModule
    {
        
        public Verifyqueryplancountandselecttopoptionsarenotenabled()
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
        	    Steps.SelectServer(Config.ServerOptions_DEFAULTSERVER);
        	    Steps.ClickOnQueriesTab();
        		Steps.ClickOnSignatureMode();
        		Steps.ClickOnConfigureQueryMonitor();
        		Steps.UnCheckEnableQueryMonitor();
        		Steps.VerifySelectTopandPlansbyareDisabled();
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
