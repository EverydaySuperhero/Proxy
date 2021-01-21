using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleApp1
{
    public class WebConnector
    {

        static int Timeout = 10;
        const string APP_PATH = null;
        private static HttpClient CreateClient(ProxyObject proxyObject = null)
        {

            var httpClientHandler = new HttpClientHandler();


            var proxyObjext = ProxyManager.GetProxy();
            if (proxyObject != null)
            {
                var proxy = new WebProxy();
                //proxy.Address = new Uri($"http://12.229.217.226:55443");
                proxy.Address = new Uri($"http://{proxyObjext.data[0].ip}:{proxyObjext.data[0].port}");
                httpClientHandler.Proxy = proxy;
            }

            return new HttpClient(handler: httpClientHandler, disposeHandler: true)
            {
                Timeout = TimeSpan.FromMinutes(Timeout)
            };
        }

        public static string GetResult(string url)
        {
            using (var client = CreateClient())
            {
                try
                {
                    var addr = APP_PATH + url;
                    var response = client.GetAsync(addr).Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

    }
}