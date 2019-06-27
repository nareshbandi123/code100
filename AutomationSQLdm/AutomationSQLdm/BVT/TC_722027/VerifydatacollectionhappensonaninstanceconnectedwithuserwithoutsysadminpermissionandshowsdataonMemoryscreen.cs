
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

namespace AutomationSQLdm.BVT.TC_722027
{
    
    [TestModule("F7C23902-F4E5-4D3A-86A0-D5919D46FF3B", ModuleType.UserCode, 1)]
    public class VerifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonMemoryscreen :Base.BaseClass, ITestModule
    {
        public VerifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonMemoryscreen()
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
        		Steps.ClickOnResourcesTab();
        		Steps.ClickOnMemoryInResourcesTab();
        		Steps.VerifyMemoryViewInResources();
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
