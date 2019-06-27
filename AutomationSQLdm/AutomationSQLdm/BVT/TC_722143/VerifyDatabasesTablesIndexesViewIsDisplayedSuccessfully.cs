
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using Ranorex.Core.Testing;
using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using Ranorex;
using Ranorex.Core;


namespace AutomationSQLdm.BVT.TC_722143
{
   
    [TestModule("93A0F737-C7E9-4D1C-B883-FFFF9E742D73", ModuleType.UserCode, 1)]
    public class VerifyDatabasesTablesIndexesViewIsDisplayedSuccessfully : Base.BaseClass, ITestModule
    {
       
        public VerifyDatabasesTablesIndexesViewIsDisplayedSuccessfully()
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
        		Steps.ClickOnTablesAndIndexesInDB();
        		Steps.VerifyTablesAndIndexesInDataBases(); 
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
