
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


namespace AutomationSQLdm.BVT.TC_722161
{
 
    [TestModule("C27AB132-A053-4D84-BB05-9F22E554B4CB", ModuleType.UserCode, 1)]
    public class VerifySessionsSummaryIsDisplaying : ITestModule
    {
        
        public VerifySessionsSummaryIsDisplaying()
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
        		Steps.ClickOnSessions();
        		Steps.VerifyAllInSummaryUnderSessions();
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
