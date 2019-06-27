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

namespace AutomationSQLdm.BVT.TC_722029
{
    
    [TestModule("91ADC576-E2DA-4611-B2CC-D0C802963416", ModuleType.UserCode, 1)]
    public class VerifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonDiskSizescreen :Base.BaseClass, ITestModule
    {
       
        public VerifydatacollectionhappensonaninstanceconnectedwithuserwithoutsysadminpermissionandshowsdataonDiskSizescreen()
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
        		Steps.ClickOnDiskSizeInResourcesTab();        		
        		Steps.VerifyDiskSizeViewInResources();
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
