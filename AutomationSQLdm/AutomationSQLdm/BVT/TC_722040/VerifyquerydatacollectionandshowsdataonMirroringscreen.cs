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

namespace AutomationSQLdm.BVT.TC_722040
{
  
    [TestModule("EFA4CD3E-325C-443D-B801-2821E2A25B68", ModuleType.UserCode, 1)]
    public class VerifyquerydatacollectionandshowsdataonMirroringscreen :Base.BaseClass, ITestModule
    {
        
        public VerifyquerydatacollectionandshowsdataonMirroringscreen()
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
        		Steps.ClickOnDataBasesTab();
        		Steps.ClickOnMirroringInDB();
        		Steps.VerifyMirroringViewInDataBases();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
    }
}
