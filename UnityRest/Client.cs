using RSG;
using System;
using System.Collections;
using UnityEngine;

namespace UnityRest
{
    public class Client: MonoBehaviour
    {
        public IPromise<string> Download(string url)
        {
            var promise = new Promise<string>();

            StartCoroutine(DownloadEnum(url, (response, ex) => {
                if (ex != null)
                {
                    promise.Reject(ex);
                } else
                {
                    promise.Resolve(response);
                }
            }));
            return promise;
        }

        public IPromise<Texture2D> DownloadImage(string url)
        {
            var promise = new Promise<Texture2D>();

            StartCoroutine(DownloadEnumImage(url, (response, ex) => {
                if (ex != null)
                {
                    promise.Reject(ex);
                }
                else
                {
                    promise.Resolve(response);
                }
            }));
            return promise;
        }

        IEnumerator DownloadEnum(string url, Action<string, Exception> done)
        {
            WWW www = new WWW(url);
            yield return www;
            if (string.IsNullOrEmpty(www.error))
            {
                done(www.text, null);
            } else
            {
                done(null, new Exception(www.error));
            }
        }

        IEnumerator DownloadEnumImage(string url, Action<Texture2D, Exception> done)
        {
            WWW www = new WWW(url);
            yield return www;
            if (string.IsNullOrEmpty(www.error))
            {
                done(www.texture, null);
            }
            else
            {
                done(null, new Exception(www.error));
            }
        }
    }
}
