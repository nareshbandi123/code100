
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

namespace AutomationSQLdm.BVT.TC_722120
{
   
    [TestModule("1F6AB091-DAFC-4CA9-84A5-2DF5844DADA2", ModuleType.UserCode, 1)]
    public class VerifyanalertresponsecanbeAddedSuccessfully :Base.BaseClass, ITestModule
    {
       
        public VerifyanalertresponsecanbeAddedSuccessfully()
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
