
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

namespace AutomationSQLdm.BVT.TC_722025
{
    
    [TestModule("DBF21D24-D9C4-46F1-86A4-03B521BD2CC7", ModuleType.UserCode, 1)]
    public class Verifydatacollectionhappensandshowsdata : Base.BaseClass,ITestModule
    {
       
        public Verifydatacollectionhappensandshowsdata()
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
        		//Steps.RightClickOnServer(Config.ServerOptions_CMWIN2016S8);
        		//Steps.ClickProperties();
        		//Steps.TestSQLAuthentication();
        		Steps.SelectRequiredServer(Config.ServerOptions_CMWIN2016S8);
        		Steps.ClickOnResourcesTab();
        		Steps.ClickOnSummaryInResourcesTab();
        		Steps.VerifySummaryViewInResources();  
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
