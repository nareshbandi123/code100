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
namespace AutomationSQLdm.BVT.TC_722038
{
   
    [TestModule("D6DE26E0-D8BA-40F6-A1D8-936A417CB9ED", ModuleType.UserCode, 1)]
    public class VerifydatashowsonBackupsRestoresscreenInDatabases :Base.BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifydatashowsonBackupsRestoresscreenInDatabases()
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
        		Steps.ClickOnBackupsAndRestoresInDB();
        		Steps.VerifyBackupsAndRestoresInDataBases();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
    }
}
