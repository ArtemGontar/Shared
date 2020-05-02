using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Bus.Messages
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ReceiveEndpointAttribute : Attribute
    {
        public Uri Uri { get; }

        public ReceiveEndpointAttribute(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException(nameof(uri));

            Uri = new Uri(uri);
        }
    }
}
