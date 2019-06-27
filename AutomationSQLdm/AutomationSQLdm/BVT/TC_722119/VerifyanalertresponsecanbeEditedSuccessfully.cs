
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

namespace AutomationSQLdm.BVT.TC_722119
{
    
    [TestModule("B6C3E09F-ED9A-473D-8BB3-B85238E1B865", ModuleType.UserCode, 1)]
    public class VerifyanalertresponsecanbeEditedSuccessfully :Base.BaseClass, ITestModule
    {
        
        public VerifyanalertresponsecanbeEditedSuccessfully()
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
        		Steps.EditAlertResponses();
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
