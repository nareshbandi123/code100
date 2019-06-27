
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

namespace AutomationSQLdm.BVT.TC_722160
{
    
    [TestModule("164FE565-1406-4FB0-923E-CB069C84C0F3", ModuleType.UserCode, 1)]
    public class VerifySessionsDetailsviewisdisplayedsuccessfully : ITestModule
    {
       
        public VerifySessionsDetailsviewisdisplayedsuccessfully()
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
        		Steps.SelectRequiredServer(Config.ServerOptions_DEFAULTSERVER);
        		Steps.VerifyDashboardView();
        		Steps.ClickOnSessions();
        		Steps.VerifySummaryUnderSessions();
        		Steps.ClickOnDetails();
        		Steps.VerifyDetailsViewUnderSessions();
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
