using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteA
{
    public partial class WebForm1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[Common.Something.CookieName];
            cookie.Domain = "maikegroup.com";
            cookie.Expires = DateTime.Now.AddDays(-30);
            Response.Cookies.Add(cookie);
            Response.Redirect("http://login.maikegroup.com");
        }
    }
}