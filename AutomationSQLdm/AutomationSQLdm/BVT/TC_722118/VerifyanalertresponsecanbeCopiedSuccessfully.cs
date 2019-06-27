
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

namespace AutomationSQLdm.BVT.TC_722118
{
    
    [TestModule("6BF08CDB-C280-4075-8DFF-E66D78909897", ModuleType.UserCode, 1)]
    public class VerifyanalertresponsecanbeCopiedSuccessfully :Base.BaseClass, ITestModule
    {
        
        public VerifyanalertresponsecanbeCopiedSuccessfully()
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
        		Steps.CopyAlertResponses();
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
