
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
namespace AutomationSQLdm.BVT.TC_722135
{
    
    [TestModule("7FFD8D19-2C1B-4421-9F2F-36CDD1B5BE2E", ModuleType.UserCode, 1)]
    public class PendingUpdateVerifythatResourcesServerWaitsviewisDisplayedSuccessfull : Base.BaseClass,ITestModule
    {
       
        public PendingUpdateVerifythatResourcesServerWaitsviewisDisplayedSuccessfull()
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
        		Steps.ClickOnResourcesTab();
        		Steps.ClickOnSummaryInResourcesTab();
        		Steps.VerifySummaryViewInResources();
        		Steps.ClickOnServerWaitsInResourcesTab();
        		Steps.VerifyServerWaitsInResources();
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
