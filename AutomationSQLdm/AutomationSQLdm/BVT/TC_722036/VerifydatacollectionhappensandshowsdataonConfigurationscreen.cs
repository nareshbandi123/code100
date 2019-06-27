/*
 * Created by Ranorex
 * User: administrator
 * Date: 4/23/2019
 * Time: 4:03 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
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
namespace AutomationSQLdm.BVT.TC_722036
{
    
    [TestModule("120537F6-5C3B-4C46-94DC-27A2216ED18E", ModuleType.UserCode, 1)]
    public class VerifydatacollectionhappensandshowsdataonConfigurationscreen :Base.BaseClass, ITestModule
    {
        
        public VerifydatacollectionhappensandshowsdataonConfigurationscreen()
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
        		Steps.ClickOnConfigurationInDB();
        		Steps.VerifyConfigurationInDataBases();
        		Steps.Verifydataonspecificdatabaseinconfiguration();
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
