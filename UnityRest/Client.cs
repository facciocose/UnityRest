using RSG;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityRest
{
    public class Client: MonoBehaviour
    {
        public IPromise<Response> Execute(Request request)
        {
            var promise = new Promise<Response>();
            StartCoroutine(ExecuteEnum(request, (response, ex) => {
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

        IEnumerator ExecuteEnum(Request request, Action<Response, Exception> done)
        {
            WWW www;

            if (request.method == Method.POST)
            {
                // concatenate headers and parameters
                Dictionary<string, string> headers = request.postParameters.headers;
                foreach (KeyValuePair<string, string> kvp in request.headers)
                {
                    headers[kvp.Key] = kvp.Value;
                }

                if (request.data != null)
                {
                    www = new WWW(request.ToString(), request.data, headers);
                }
                else
                {
                    www = new WWW(request.ToString(), request.postParameters.data, headers);
                }
            } else
            {
                www = new WWW(request.ToString(), null, request.headers);
            }
            yield return www;
            if (string.IsNullOrEmpty(www.error))
            {
                done(new Response(www.text, www.responseHeaders), null);
            }
            else
            {
                done(null, new Exception(www.error));
            }
        }

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
