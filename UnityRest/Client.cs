using RSG;
using System;
using System.Net;

namespace UnityRest
{
    public class Client
    {
        public IPromise<string> Download(string url)
        {
            var promise = new Promise<string>();
            using(var client = new WebClient())
            {
                client.DownloadStringCompleted += (s, ev) =>
                {
                    if (ev.Error != null)
                    {
                        promise.Reject(ev.Error);
                    }
                    else
                    {
                        promise.Resolve(ev.Result);
                    }
                };
                client.DownloadStringAsync(new Uri(url), null);
            }
            return promise;
        }
    }
}
