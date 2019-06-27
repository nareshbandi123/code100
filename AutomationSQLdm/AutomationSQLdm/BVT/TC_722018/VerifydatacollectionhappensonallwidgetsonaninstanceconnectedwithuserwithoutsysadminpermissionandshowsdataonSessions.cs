
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

namespace AutomationSQLdm.BVT.TC_722018
{
    
    [TestModule("0DB37947-2EDC-4F80-AC47-4F47055B3A8F", ModuleType.UserCode, 1)]
    public class VerifydatacollectionhappensonallwidgetsonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonSessions :Base.BaseClass, ITestModule
    {
       
        public VerifydatacollectionhappensonallwidgetsonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonSessions()
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
        		Steps.ClickOnSessions();
        		Steps.VerifySummarygraphsUnderSessions();
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
