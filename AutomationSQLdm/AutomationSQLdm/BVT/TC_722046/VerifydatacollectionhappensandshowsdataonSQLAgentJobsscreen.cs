
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
namespace AutomationSQLdm.BVT.TC_722046
{
    
    [TestModule("572D253C-F102-4B31-AEDE-0BFB0D202019", ModuleType.UserCode, 1)]
    public class VerifydatacollectionhappensandshowsdataonSQLAgentJobsscreen :Base.BaseClass, ITestModule
    {
        
        public VerifydatacollectionhappensandshowsdataonSQLAgentJobsscreen()
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
        		Steps.RightClickOnServer(Config.ServerOptions_SQLAUTHSERVER);
        		Steps.ClickProperties();
        	    Steps.TestSQLAuthentication();
        		Steps.SelectRequiredServer(Config.ServerOptions_SQLAUTHSERVER);
        		Steps.ClickOnServicesTab();        		
        		Steps.VerifySummaryInServices();
        		Steps.ClickOnSqlAgentJobsInServices();
        		Steps.VerifySqlAgentJobsInServices();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
       
    }
}
