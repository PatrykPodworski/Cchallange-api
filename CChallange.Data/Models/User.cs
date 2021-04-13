using System;
using System.Collections.Generic;

namespace CChallange.Data
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Submition> Submitions { get; set; }
    }
}
