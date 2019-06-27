
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

namespace AutomationSQLdm.Grooming_Modifications.TC_721944
{
    
    [TestModule("07961294-8C4F-409C-BAEB-06255200A69C", ModuleType.UserCode, 1)]
    public class VerifyGroomForecastingData : Base.BaseClass, ITestModule
    {
        
        public VerifyGroomForecastingData()
        {
        }

        void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.VerifyGroomforecastingValue();
        		Steps.ClickOnCancel();
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
