using System;
using System.Web;

namespace LogIn
{
    public partial class _default : System.Web.UI.Page
    {
        private string backUrl = string.Empty;

        public string BackUrl
        {
            get { return backUrl; }
            set { backUrl = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["backurl"] != null)
                {
                    BackUrl = Request.QueryString["backurl"];
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text.Trim()) || string.IsNullOrEmpty(TextBox2.Text.Trim()))
                return;

            com.maikegroup.passport.WebService1 webservice = new com.maikegroup.passport.WebService1();
            string token = webservice.CheckUser(TextBox1.Text.Trim(), TextBox2.Text.Trim());

            if (!string.IsNullOrEmpty(token))
            {
                CreateCookie(token);
                //if (!string.IsNullOrEmpty(backUrl))
                //    Response.Redirect(backUrl);
                //else
                    Response.Redirect("main.aspx");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "账号密码不正确");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
        }

        private void CreateCookie(string value)
        {
            HttpCookie tokenCookie = new HttpCookie(Common.Something.CookieName, value)
            {
                Domain = "maikegroup.com",
                Path = "/",
                Expires = DateTime.Now.AddMinutes(Common.Something.TimeOut)
            };
            Response.Cookies.Add(tokenCookie);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                HttpCookie c = Request.Cookies[i];
                if (c != null && c.HasKeys)
                {
                    for (int j = 0; j < c.Values.Count - 1; j++)
                    {
                        string subKeyName = Server.HtmlEncode(c.Values.AllKeys[j]);
                        string subKeyValue = Server.HtmlEncode(c.Values[j]);
                        Response.Write("subKeyName = " + subKeyName + ", subKeyValue = " + subKeyValue + "<br />");
                    }
                }
                else if (c != null) Response.Write(c.Name + " " + c.Value + "<br />");
            }
        }
    }
}