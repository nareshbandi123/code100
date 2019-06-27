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

namespace AutomationSQLdm.BVT.TC_722030
{
    
    [TestModule("20112678-EA54-4439-934A-3F2C33E0FB0A", ModuleType.UserCode, 1)]
    public class VerifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonFileActivityscreen :Base.BaseClass, ITestModule
    {
        
        public VerifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonFileActivityscreen()
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
        		Steps.ClickOnFileActivityInResourcesTab();        		
        		Steps.VerifyFileActivityInResources();
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
