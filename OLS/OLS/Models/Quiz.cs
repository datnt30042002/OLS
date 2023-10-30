﻿using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }

        public int QuizId { get; set; }
        public int? LessonLessonId { get; set; }

        public virtual Lesson? LessonLesson { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
