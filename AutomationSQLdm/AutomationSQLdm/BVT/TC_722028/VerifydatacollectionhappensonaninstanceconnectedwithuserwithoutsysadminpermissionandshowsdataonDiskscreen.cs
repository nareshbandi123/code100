
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
namespace AutomationSQLdm.BVT.TC_722028
{
    
    [TestModule("E6B29AF8-F6AB-4B8A-8490-01EDB61138A8", ModuleType.UserCode, 1)]
    public class VerifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonDiskscreen :Base.BaseClass, ITestModule
    {
       
        public VerifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonDiskscreen()
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
        		Steps.ClickOnDiskInResourcesTab();
        		Steps.VerifyDiskViewInResources();
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
