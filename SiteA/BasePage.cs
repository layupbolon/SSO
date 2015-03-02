using System;
using System.Web;
using System.Web.UI;

namespace SiteA
{
    /// <summary>
    /// 页面基类
    /// </summary>
    public class BasePage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies[Common.Something.CookieName] != null)
                {
                    HttpCookie cookie = Request.Cookies[Common.Something.CookieName];
                    cookie.Domain = "maikegroup.com";
                    cookie.Expires = DateTime.Now.AddMinutes(Common.Something.TimeOut);
                    Response.Cookies.Add(cookie);

                    var webservice = new com.maikegroup.passport.WebService1();
                    string json = webservice.TokenGetCredence(Request.Cookies[Common.Something.CookieName].Value);

                    //Page.ClientScript.RegisterClientScriptBlock(typeof(string), "error", json);
                    if (!string.IsNullOrEmpty(json))
                    {
                        Common.User user = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.User>(json); 
                        Page.ClientScript.RegisterStartupScript(GetType(), "message", string.Format("欢迎 {0} 登录站点A!", user.UserName));
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "error", "<script>alert('cache不存在或失效');</script>");
                        Response.Redirect("http://login.maikegroup.com?backurl=sitea.maikegroup.com");
                    }
                }
                else
                {
                    Response.Redirect("http://login.maikegroup.com?backurl=sitea.maikegroup.com");
                }
            }

            base.OnLoad(e);
        }
    }
}
