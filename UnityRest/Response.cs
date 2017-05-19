using System.Collections.Generic;

namespace UnityRest
{
    public class Response
    {
        public string data;
        public Dictionary<string, string> headers;

        public Response(string data, Dictionary<string, string> headers)
        {
            this.data = data;
            this.headers = headers;
        }
    }
}
