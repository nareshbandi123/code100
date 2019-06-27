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
namespace AutomationSQLdm.BVT.TC_722022
{
   
    [TestModule("35A7C899-0811-4E0E-A5CC-379AD3A3B4B9", ModuleType.UserCode, 1)]
    public class Verifyquerydatacollectionhappensononaninstanceconnectedwithuserwithoutsysadminpermission : Base.BaseClass,ITestModule
    {
        
        public Verifyquerydatacollectionhappensononaninstanceconnectedwithuserwithoutsysadminpermission()
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
        		Steps.RightClickOnServer(Config.ServerOptions_SQLAUTHSERVER);
        		Steps.ClickProperties();
        		Steps.TestSQLAuthentication();
        		Steps.SelectRequiredServer(Config.ServerOptions_SQLAUTHSERVER);
        		Steps.ClickOnQueriesTab();
        		Steps.ClickOnStatementMode();
        		Steps.VerifyStatementModeIsDisplayed();
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
