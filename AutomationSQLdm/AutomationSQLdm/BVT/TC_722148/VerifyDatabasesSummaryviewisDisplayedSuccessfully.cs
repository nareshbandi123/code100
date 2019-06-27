
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


namespace AutomationSQLdm.BVT.TC_722148
{
    
    [TestModule("36A7C977-25B8-4D53-A7EC-AEB90911E290", ModuleType.UserCode, 1)]
    public class VerifyDatabasesSummaryviewisDisplayedSuccessfully :Base.BaseClass, ITestModule
    {
      
        public VerifyDatabasesSummaryviewisDisplayedSuccessfully()
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
        		Steps.ClickOnDataBasesTab();
        		Steps.VerifySummaryInDataBases();
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
