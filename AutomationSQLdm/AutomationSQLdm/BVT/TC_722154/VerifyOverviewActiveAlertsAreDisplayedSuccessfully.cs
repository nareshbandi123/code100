
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

namespace AutomationSQLdm.BVT.TC_722154
{
    
    [TestModule("DE74A158-FD3C-47D0-991D-27210B9D4008", ModuleType.UserCode, 1)]
    public class VerifyOverviewActiveAlertsAreDisplayedSuccessfully :Base.BaseClass, ITestModule
    {
       
        public VerifyOverviewActiveAlertsAreDisplayedSuccessfully()
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
        		Steps.SelectRequiredServer(Config.ServerOptions_DEFAULTSERVER);
        		Steps.VerifyDashboardView();
        		Steps.ClickOnActiveAlertsInOverView();
        		Steps.VerifyActiveAlertsInOverView();
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
