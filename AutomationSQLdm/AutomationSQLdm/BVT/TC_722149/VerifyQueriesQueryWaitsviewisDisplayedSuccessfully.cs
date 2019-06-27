
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


namespace AutomationSQLdm.BVT.TC_722149
{
    
    [TestModule("FC365446-9937-4703-8523-EC23E6B919CD", ModuleType.UserCode, 1)]
    public class VerifyQueriesQueryWaitsviewisDisplayedSuccessfully :Base.BaseClass, ITestModule
    {
       
        public VerifyQueriesQueryWaitsviewisDisplayedSuccessfully()
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
        		Steps.ClickOnQueriesTab();
        		Steps.VerifySignatureModeIsDisplayed();
        		Steps.ClickOnQueryWaits();
        		Steps.VerifyQueryWaitsIsDisplayed();
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
