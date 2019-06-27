
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
using AutomationSQLdm.Base;

namespace AutomationSQLdm.Grooming_Modifications.TC_21948
{
    /// <summary>
    /// Description of VerifyDefaultMetricsDataToBeGroomedAs90days.
    /// </summary>
    [TestModule("D648E47A-4B2C-41AE-ABBC-2B0D904E746A", ModuleType.UserCode, 1)]
    public class VerifyDefaultMetricsDataToBeGroomedAs90days : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyDefaultMetricsDataToBeGroomedAs90days()
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
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.VerifyDefaultMetricsDataAs90Days(); 
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
