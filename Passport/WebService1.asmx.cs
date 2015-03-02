using System;
using System.Web;
using System.Web.Services;

namespace Passport
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://passport.maikegroup.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : WebService
    {
        [WebMethod]
        public string TokenGetCredence(string tokenValue)
        {
            return CacheManager.GetCacheValue(tokenValue);
        }

        [WebMethod]
        public string CheckUser(string userName, string password)
        {
            if (CheckUserLogIn(userName, password))
            {
                string token = CreateToken();

                Common.User user = new Common.User(userName, password);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(user);

                CacheManager.CacheInsert(token, json);

                return token;
            }

            return string.Empty;
        }

        private string CreateToken()
        {
            return Guid.NewGuid().ToString();
        }

        private bool CheckUserLogIn(string userName, string password)
        {
            if ((userName.Equals("1") && password.Equals("1")) || (userName.Equals("2") && password.Equals("2")))
                return true;

            return false;
        }
    }




    public static class CacheManager
    {
        public static void CacheInsert(string key, object value)
        {
            //Insert存在相同的键会替换，无返回值
            //Add 存在相同的键会异常，返回缓存成功的对象
            //Cache的过期策略使用滑动过期
            HttpRuntime.Cache.Insert(key, value, null, DateTime.MaxValue, TimeSpan.FromMinutes(Common.Something.TimeOut));
        }

        public static string GetCacheValue(string key)
        {
            if (HttpRuntime.Cache[key] != null)
            {
                return HttpRuntime.Cache[key].ToString();
            }
            return string.Empty;
        }
    }
}
