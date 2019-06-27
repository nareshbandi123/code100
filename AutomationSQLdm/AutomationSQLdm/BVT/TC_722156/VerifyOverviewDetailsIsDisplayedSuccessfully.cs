
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

namespace AutomationSQLdm.BVT.TC_722156
{
    
    [TestModule("DCE06FEF-EABD-4E5D-B4C1-23594291A53D", ModuleType.UserCode, 1)]
    public class VerifyOverviewDetailsIsDisplayedSuccessfully :Base.BaseClass, ITestModule
    {
       
        public VerifyOverviewDetailsIsDisplayedSuccessfully()
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
        		Steps.ClickOnDetailsInOverView();
        		Steps.VerifyDetailsInOverView();
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
