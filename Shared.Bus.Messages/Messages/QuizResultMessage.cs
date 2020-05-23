using System;

namespace Shared.Bus.Messages
{
    [ReceiveEndpoint("queue:quiz-result")]
    public class QuizResultMessage : IMessage
    {
        public int QuestionsCount { get; set; }
        public int CorrectAnswersCount { get; set; }
        public int FailedAnswersCount { get; set; }
        public double CorrectPercent { get; set; }
        public Guid QuizId { get; set; }
        public string QuizTitle { get; set; }
        public Guid UserId { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
