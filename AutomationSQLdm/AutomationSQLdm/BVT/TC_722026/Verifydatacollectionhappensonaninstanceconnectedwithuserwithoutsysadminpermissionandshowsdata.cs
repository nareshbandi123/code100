
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

namespace AutomationSQLdm.BVT.TC_722026
{
    [TestModule("C085DC47-F56C-434F-AA8C-C52961CE6DBC", ModuleType.UserCode, 1)]
    public class Verifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdata :Base.BaseClass ,ITestModule
    {
        
        public Verifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdata()
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
        		Steps.ClickOnCPUInResourcesTab();
        		Steps.VerifyCPUViewInResources();
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
