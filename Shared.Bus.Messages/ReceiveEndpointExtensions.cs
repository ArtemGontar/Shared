using System;

namespace Shared.Bus.Messages
{
    public static class ReceiveEndpointExtensions
    {
        public static Uri GetReceiveEndpoint(this IMessage message)
        {
            var customAttributes = message.GetType().GetCustomAttributes(typeof(ReceiveEndpointAttribute), false);
            if (customAttributes == null || customAttributes.Length == 0)
                throw new ArgumentNullException(nameof(customAttributes));

            var receiveEndpointAttr = (ReceiveEndpointAttribute)customAttributes[0];

            return receiveEndpointAttr.Uri;
        }

        public static Uri GetReceiveEndpoint(this Type type)
        {
            var customAttributes = type.GetCustomAttributes(typeof(ReceiveEndpointAttribute), false);
            if (customAttributes == null || customAttributes.Length == 0)
                throw new ArgumentNullException(nameof(customAttributes));

            var receiveEndpointAttr = (ReceiveEndpointAttribute)customAttributes[0];

            return receiveEndpointAttr.Uri;
        }
    }
}
