
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

namespace AutomationSQLdm.BVT.TC_722140
{
    
    [TestModule("00E817CD-58EE-4BF2-A634-267994437B5F", ModuleType.UserCode, 1)]
    public class VerifythatResourcesCPUisDisplayedSuccessfully :Base.BaseClass, ITestModule
    {
       
        public VerifythatResourcesCPUisDisplayedSuccessfully()
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
        		Steps.ClickOnCPUInResourcesTab();
        		Steps.VerifyCPUViewInResources();
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
