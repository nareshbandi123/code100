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
using AutomationSQLdm.Grooming_Modifications;

namespace AutomationSQLdm.QueryPlan.TC_722081
{
    
    [TestModule("4434A720-B45D-40E3-919D-C07AE666718E", ModuleType.UserCode, 1)]
    public class VerifyQueryStoreradioButtonisnewlyaddedfor2016and2017versioninstances :Base.BaseClass,ITestModule
    {
       
        public VerifyQueryStoreradioButtonisnewlyaddedfor2016and2017versioninstances()
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
        		
        		Steps.SelectServer(Config.ServerOptions_DEFAULTSERVER); //Version 2016
        		Steps.ClickOnQueriesTab();
        		Steps.ClickOnSignatureMode();
        		Steps.ClickOnConfigureQueryMonitor();
        		Steps.CheckEnableQueryMonitor();
        		Steps.VerifyQueryStoreRB();
        		Steps.ClickOnOkInMSSP();
        		Steps.ClickOnWarningYes();
        		Steps.SelectServer(Config.ServerOptions_DEFAULTSERVER); //Version 2017
        		Steps.ClickOnQueriesTab();
        		Steps.ClickOnSignatureMode();
        		Steps.ClickOnConfigureQueryMonitor();
        		Steps.CheckEnableQueryMonitor();
        		Steps.VerifyQueryStoreRB();
        		Steps.ClickOnOkInMSSP();
        		Steps.ClickOnWarningYes();
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
