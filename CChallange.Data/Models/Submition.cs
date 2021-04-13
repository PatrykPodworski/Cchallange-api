using System;

namespace CChallange.Data
{
    public class Submition
    {
        public string Id { get; set; }
        public string TaskId { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
}
}
