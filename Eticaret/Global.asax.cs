using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Eticaret
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/jquery-1.11.1.min.js",
                DebugPath = "~/jquery-1.11.1.min.js",
                CdnPath = "~/jquery-1.11.1.min.js",
                CdnDebugPath = "~/jquery-1.11.1.min.js"
            });
        }
    }
}