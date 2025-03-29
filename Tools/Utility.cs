using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Utility
    {
        /// <summary>
        /// 获取根路径
        /// </summary>
        /// <returns>项目根路径</returns>
        public static string GetAppDomainRootPath() {
            string baseUrl = AppDomain.CurrentDomain.BaseDirectory;
            string name = AppDomain.CurrentDomain.FriendlyName;
            string rootUrl = baseUrl.Substring(0, baseUrl.IndexOf(name));

            return rootUrl;
        }
    }
}
