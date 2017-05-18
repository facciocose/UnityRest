namespace UnityRest
{
    public class Request
    {
        string url;
        Method method;
        QueryStringBuilder getParameters;

        public Request(string url, Method method)
        {
            this.url = url;
            this.method = method;
            this.getParameters = new QueryStringBuilder();
        }

        public void AddParameter(string name, object value)
        {
            getParameters.Add(name, value.ToString());
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
