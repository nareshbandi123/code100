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
namespace AutomationSQLdm.QueryPlan.TC_722070
{
    /// <summary>
    /// Description of Verifyqueryplansoptionsarenotenabled.
    /// </summary>
    [TestModule("1C0AA605-3CCF-4D1C-8819-1897A849051B", ModuleType.UserCode, 1)]
    public class Verifyqueryplansoptionsarenotenabled :Base.BaseClass,ITestModule
    {
        
        public Verifyqueryplansoptionsarenotenabled()
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
        	    Steps.SelectServer(Config.ServerOptions_DEFAULTSERVER);
        	    Steps.RightClickOnServerQP(Config.ServerOptions_DEFAULTSERVER);
        		Steps.ClickPropertiesQP();
        		Steps.ClickOnOueryMonitorTab();
        		Steps.Verifyqueryplansoptionsaredisabled();
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
