﻿namespace ExCursed.BLL.DTOs.Test
{
    public class TestDTO
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public int DurationMinutes { get; set; }

        public bool ShuffleQuestions { get; set; }

        public bool ShuffleVariants { get; set; }

        public int AttemptsAllowed { get; set; }

        public float MaxMark { get; set; }
    }
}
