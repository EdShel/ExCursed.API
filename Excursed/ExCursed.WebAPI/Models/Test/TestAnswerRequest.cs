using System.Collections.Generic;

namespace ExCursed.WebAPI.Models.Test
{
    public class TestAnswerRequest
    {
        public int AttemptId { get; set; }

        public int QuestionId { get; set; }

        public IEnumerable<int> SelectedAnswers { get; set; }
    }
}
