
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

namespace AutomationSQLdm.BVT.TC_722114
{
    
    [TestModule("F5EDEEB7-7A5D-4721-8FBE-28D988ABC015", ModuleType.UserCode, 1)]
    public class BVTVerifyanactionprovidercanbeRemovedSuccessfully : Base.BaseClass, ITestModule
    {
        public BVTVerifyanactionprovidercanbeRemovedSuccessfully()
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
        		Steps.ClickonActionProvidersOption();
        		Steps.AddActionProviders();
        		Steps.ClickOnAddRemoveInActionProviders();
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
