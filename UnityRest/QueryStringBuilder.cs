using System;
using System.Collections.Generic;

namespace UnityRest
{
    class QueryStringBuilder: List<KeyValuePair<string, string>>
    {
        public void Add(string name, string value)
        {

        }

        public override string ToString()
        {
            List<string> output = new List<string>();

            foreach(KeyValuePair<string, string> kvp in this)
            {
                output.Add(String.Concat(Uri.EscapeDataString(kvp.Key), "=", Uri.EscapeDataString(kvp.Value)));
            }

            return String.Join("&", output.ToArray());
        }
    }
}
