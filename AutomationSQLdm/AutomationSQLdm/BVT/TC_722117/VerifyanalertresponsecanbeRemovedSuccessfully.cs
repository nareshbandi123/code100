
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
namespace AutomationSQLdm.BVT.TC_722117
{
    
    [TestModule("2A3A97B6-3AB4-4084-9D30-AE09A96BF2FA", ModuleType.UserCode, 1)]
    public class VerifyanalertresponsecanbeRemovedSuccessfully :Base.BaseClass, ITestModule
    {
        
        public VerifyanalertresponsecanbeRemovedSuccessfully()
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
        		Steps.ClickOnTools();
        		Steps.SelectAlertActionsandResponsesOption();
        		Steps.AddAlertResponses();
        		Steps.ClickOnTools();
        		Steps.SelectAlertActionsandResponsesOption();
        		Steps.RemoveAlertResponses();
        		Steps.ClickOnTools();
        		Steps.SelectAlertActionsandResponsesOption();
        		Steps.ClickonActionProvidersOption();
        		Steps.ClickOnAddRemoveInActionProviders();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
        
    }
}
