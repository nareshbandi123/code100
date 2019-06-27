
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

namespace AutomationSQLdm.BVT.TC_722136
{
    
    [TestModule("1901345D-1D5E-45FB-A9C0-FFF68F726509", ModuleType.UserCode, 1)]
    public class VerifyResourcesProcedureCacheViewIsDisplayedSuccessfully : Base.BaseClass, ITestModule
    {
        
        public VerifyResourcesProcedureCacheViewIsDisplayedSuccessfully()
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
        		Steps.ClickOnResourcesTab();
        		Steps.ClickOnSummaryInResourcesTab();
        		Steps.VerifySummaryViewInResources();
        		Steps.ClickOnProcedureCacheInResourcesTab();
        		Steps.VerifyProcedureCacheInResources();
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
