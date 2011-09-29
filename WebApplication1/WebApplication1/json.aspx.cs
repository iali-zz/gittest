using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace WebApplication1
{
    public partial class json : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager sm = new ScriptManager();
            sm.EnablePageMethods = true;
            
            this.form1.Controls.Add(sm);
        }

        [WebMethod]
        public static string SayHello()
        {
            return HttpContext.Current.Request.RawUrl + " -> " + HttpContext.Current.Request.Url;
        }  
    }
}