
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

namespace AutomationSQLdm.BVT.TC_722145
{
    
    [TestModule("5BED732A-DFC4-4B29-BF9D-308FE71C754F", ModuleType.UserCode, 1)]
    public class VerifyDatabasesFilesviewisDisplayedSuccessfully :Base.BaseClass, ITestModule
    {
        
        public VerifyDatabasesFilesviewisDisplayedSuccessfully()
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
        		Steps.ClickOnFilesInDB();
        		Steps.VerifyFilesInDataBases();     
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
