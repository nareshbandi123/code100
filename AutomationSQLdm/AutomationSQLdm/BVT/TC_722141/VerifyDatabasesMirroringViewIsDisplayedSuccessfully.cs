using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace AutomationSQLdm.BVT.TC_722141
{
   
    [TestModule("BA33E39D-3C34-4D74-9B06-BE430935E9E7", ModuleType.UserCode, 1)]
    public class VerifyDatabasesMirroringViewIsDisplayedSuccessfully : Base.BaseClass,ITestModule
    {        
        public VerifyDatabasesMirroringViewIsDisplayedSuccessfully()
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
        		Steps.ClickOnMirroringInDB();
        		Steps.VerifyMirroringViewInDataBases();
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
