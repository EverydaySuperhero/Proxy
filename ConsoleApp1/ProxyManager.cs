using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    internal static class ProxyManager
    {
        internal static ProxyObject GetProxy()
        {
            var getProxyString = "http://pubproxy.com/api/proxy";
            var webRequest = (HttpWebRequest)WebRequest.Create(getProxyString);
            if (webRequest == null)
                return null;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            var s1 = webRequest.GetResponse().GetResponseStream();
            using var sr1 = new StreamReader(s1);
            var result = JsonConvert.DeserializeObject<ProxyObject>(sr1.ReadToEnd());
            Console.WriteLine($"Proxy type {result.data[0].type} \n " +
            $"{result.data[0].ip} \n " +
            $"{result.data[0].port}");
            return result;
        }

    }
}
