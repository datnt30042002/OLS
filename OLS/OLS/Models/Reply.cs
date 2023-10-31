﻿using System;
using System.Collections.Generic;

namespace OLS.Models
{
    public partial class Reply
    {
        public int ReplyId { get; set; }
        public string? ReplyContent { get; set; }
        public int? AskAskId { get; set; }

        public virtual Ask? AskAsk { get; set; }
    }
}