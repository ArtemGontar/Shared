using System;

namespace Shared.Bus.Messages
{
    [ReceiveEndpoint("queue:delete-chapter")]
    public class DeleteChapterMessage : IMessage
    {
        public Guid OwnerId { get; set; }
        public Guid ChapterId { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
