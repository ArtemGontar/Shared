using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Bus.Messages.Messages
{
    public class DeleteQuizMessage : IMessage
    {
        public Guid OwnerId { get; set; }
        public Guid QuizId { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
