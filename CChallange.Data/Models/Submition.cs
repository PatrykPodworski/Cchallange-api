using System;

namespace CChallange.Data
{
    public class Submition
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public string Code { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
}
}
