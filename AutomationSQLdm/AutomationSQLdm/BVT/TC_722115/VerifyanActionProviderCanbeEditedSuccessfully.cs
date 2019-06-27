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

namespace AutomationSQLdm.BVT.TC_722115
{
    
    [TestModule("B1122AD3-0F31-4221-AEB7-F6C896B955B5", ModuleType.UserCode, 1)]
    public class VerifyanActionProviderCanbeEditedSuccessfully : ITestModule
    {
        
        public VerifyanActionProviderCanbeEditedSuccessfully()
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
        		Steps.ClickOnTools();
        		Steps.SelectAlertActionsandResponsesOption();
        		Steps.ClickonActionProvidersOption();
        		Steps.AddActionProviders();  
        		Steps.EditActionProviders();
        		Steps.ClickOnEditRemoveInActionProviders();
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
