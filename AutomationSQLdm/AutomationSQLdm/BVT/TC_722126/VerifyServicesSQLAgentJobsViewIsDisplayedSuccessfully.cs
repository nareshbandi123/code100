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

namespace AutomationSQLdm.BVT.TC_722126
{
   
    [TestModule("C4BCCF7D-D881-471E-AB10-5BBA3BD4818F", ModuleType.UserCode, 1)]
    public class VerifyServicesSQLAgentJobsViewIsDisplayedSuccessfully :Base.BaseClass, ITestModule
    {
        
        public VerifyServicesSQLAgentJobsViewIsDisplayedSuccessfully()
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
        		Steps.ClickOnServicesTab();
        		Steps.VerifySummaryInServices(); 
        		Steps.ClickOnSqlAgentJobsInServices();
        		Steps.VerifySqlAgentJobsInServices(); 
        		Steps.VerifySqlAgentJobsJobsHistoryInServices();
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
