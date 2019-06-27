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

namespace AutomationSQLdm.QueryPlan.TC_722084
{
    [TestModule("5F161574-DEC6-4D1A-A7FE-1006736033EA", ModuleType.UserCode, 1)]
    public class VerifyQueryStoreoptionisnotselectedbydefault :Base.BaseClass, ITestModule
    {
       
        public VerifyQueryStoreoptionisnotselectedbydefault()
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
        	    Steps.SelectServer(Config.ServerOptions_DEFAULTSERVER);        	   
        	    Steps.RightClickOnServerQP(Config.ServerOptions_DEFAULTSERVER);
        		Steps.ClickPropertiesQP();
        		Steps.ClickOnWaitMonitoringtab();
        		Steps.VerifyUseExtendedEventsCheckboxisEnabled();
        		Steps.ClickOnOkInMSSP();        		        		        	        
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
