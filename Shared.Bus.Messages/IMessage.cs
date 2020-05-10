using System;
namespace Shared.Bus.Messages
{
    public interface IMessage
    { 
        DateTime TimeStamp { get; set; }
    }
}
