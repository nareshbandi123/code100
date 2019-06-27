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


namespace AutomationSQLdm.Grooming_Modifications.TC_21960
{
    /// <summary>
    /// Description of VerifyValuesInRepositoryTable.
    /// </summary>
    [TestModule("36CEA6AD-DDAA-417B-8EA6-DF77A606559F", ModuleType.UserCode, 1)]
    public class VerifyValuesInRepositoryTable : Base.BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyValuesInRepositoryTable()
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
        		Steps.VerifyFieldsAreEditable();
//        		Steps.ClickOnCancel();
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
