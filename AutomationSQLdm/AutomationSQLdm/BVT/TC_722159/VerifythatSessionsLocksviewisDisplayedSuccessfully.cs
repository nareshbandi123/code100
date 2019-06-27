
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


namespace AutomationSQLdm.BVT.TC_722159
{
    
    [TestModule("2C0D2C48-5EB2-4DE8-BA46-778A00280002", ModuleType.UserCode, 1)]
    public class VerifythatSessionsLocksviewisDisplayedSuccessfully :Base.BaseClass, ITestModule
    {
        
        public VerifythatSessionsLocksviewisDisplayedSuccessfully()
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
        		Steps.VerifySummaryUnderSessions();
        		Steps.ClickOnLocks();
        		Steps.VerifyLocksUnderSessions();      
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
