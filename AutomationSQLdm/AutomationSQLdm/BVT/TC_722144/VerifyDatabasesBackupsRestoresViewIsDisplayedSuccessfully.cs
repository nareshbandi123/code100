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

namespace AutomationSQLdm.BVT.TC_722144
{
   
    [TestModule("2946415D-9089-4C6E-9126-4EBE6AE95095", ModuleType.UserCode, 1)]
    public class VerifyDatabasesBackupsRestoresViewIsDisplayedSuccessfully : Base.BaseClass,ITestModule
    {
       
        public VerifyDatabasesBackupsRestoresViewIsDisplayedSuccessfully()
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
        		Steps.ClickOnBackupsAndRestoresInDB();
        		Steps.VerifyBackupsAndRestoresInDataBases();
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
