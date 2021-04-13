﻿using System;

namespace CChallange.Data
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
