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

namespace AutomationSQLdm.BVT.TC_722039
{
    
    [TestModule("8E9A2FF5-A6DC-464C-BADB-693E0B574608", ModuleType.UserCode, 1)]
    public class VerifydatacollectionandshowsdataonTablesandIndexesscreen :Base.BaseClass, ITestModule
    {
       
        public VerifydatacollectionandshowsdataonTablesandIndexesscreen()
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
        		Steps.ClickOnTablesAndIndexesInDB();
        		Steps.VerifyTablesAndIndexesInDataBases();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
    }
}
