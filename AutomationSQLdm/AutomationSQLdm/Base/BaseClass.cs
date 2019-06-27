
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

using AutomationSQLdm.Base;
using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using AutomationSQLdm.Extensions;

namespace AutomationSQLdm.Base
{
 
    public class BaseClass 
    {
        
        public BaseClass()
        {
        	Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Ranorex.Controls.ProgressForm.Hide();  
            
            Config.TestCaseName = ((TestCaseNode)TestSuite.CurrentTestContainer).Name;
           
        }

    }
}
