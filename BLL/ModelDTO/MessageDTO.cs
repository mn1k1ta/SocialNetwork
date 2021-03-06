﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public int RoomId { get; set; }
        public string SenderId { get; set; }
        public string ReapientId { get; set; }
        public string MessageText { get; set; }
        public DateTime Date { get; set; }
    }
}
