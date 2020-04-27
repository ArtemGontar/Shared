using System;

namespace Shared.Bus.Messages
{
    public class DeleteChapterMessage
    {
        public DateTime TimeStamp { get; }
        public Guid OwnerId { get; }
        public Guid ChapterId { get; }
    }
}
