

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

namespace AutomationSQLdm.BVT.TC_722146
{
    
    [TestModule("04649D34-D458-4684-A715-AC348E11810C", ModuleType.UserCode, 1)]
    public class VerifyDatabasesConfigurationviewisDisplayedSuccessfully : Base.BaseClass,ITestModule
    {
       
        public VerifyDatabasesConfigurationviewisDisplayedSuccessfully()
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
        		Steps.ClickOnConfigurationInDB();
        		Steps.VerifyConfigurationInDataBases();
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
