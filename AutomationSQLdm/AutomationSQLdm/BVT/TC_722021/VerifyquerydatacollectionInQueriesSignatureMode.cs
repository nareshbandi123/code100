
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

namespace AutomationSQLdm.BVT.TC_722021
{
    
    [TestModule("A71AD632-431F-4028-9737-FC0EFCF72AF1", ModuleType.UserCode, 1)]
    public class VerifyquerydatacollectionInQueriesSignatureMode :Base.BaseClass, ITestModule
    {
        
        public VerifyquerydatacollectionInQueriesSignatureMode()
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
        		Steps.RightClickOnServer(Config.ServerOptions_SQLAUTHSERVER);
        		Steps.ClickProperties();
        		Steps.TestSQLAuthentication();
        		Steps.SelectRequiredServer(Config.ServerOptions_SQLAUTHSERVER);
        		Steps.ClickOnQueriesTab();
        		Steps.VerifySignatureModeIsDisplayed();
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
