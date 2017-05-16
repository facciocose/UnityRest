namespace UnityRest
{
    class Request
    {
        string url;

        public Request(string url, Method method)
        {
            this.url = url;
        }
    }
}
