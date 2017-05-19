using System.Collections.Generic;
using UnityEngine;

namespace UnityRest
{
    public class Request
    {
        string url;
        public Method method;
        QueryStringBuilder getParameters;
        public WWWForm postParameters;
        public Dictionary<string, string> headers { get; private set; }
        public byte[] data;

        public Request(string url, Method method)
        {
            this.url = url;
            this.method = method;
            getParameters = new QueryStringBuilder();
            postParameters = new WWWForm();
            headers = new Dictionary<string, string>();
        }

        public void AddParameter(string name, object value)
        {
            if (method == Method.GET)
            {
                getParameters.Add(name, value.ToString());
            } else
            {
                postParameters.AddField(name, value.ToString());
            }
        }

        public void AddHeader(string name, string value)
        {
            headers[name] = value;
        }

        public void AddData(string fieldname, byte[] data)
        {
            postParameters.AddBinaryData(fieldname, data);
        }

        public void AddData(byte[] data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            if (getParameters.Count > 0)
            {
                return url + "?" + getParameters.ToString();
            }
            return url;
        }
    }
}
