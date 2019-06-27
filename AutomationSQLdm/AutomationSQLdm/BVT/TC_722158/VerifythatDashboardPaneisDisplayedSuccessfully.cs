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


namespace AutomationSQLdm.BVT.TC_722158
{
    
    [TestModule("E610C7C2-135A-4E35-95C2-92C0C1DD40C8", ModuleType.UserCode, 1)]
    public class VerifythatDashboardPaneisDisplayedSuccessfully :Base.BaseClass, ITestModule
    {
        
        public VerifythatDashboardPaneisDisplayedSuccessfully()
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
        		Steps.VerifyAllInDashboardView();
        		
       		        		
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }

        
    }
}
