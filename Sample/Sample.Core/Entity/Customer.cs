using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sample.Core.Extensions;

namespace Sample.Core.Entity
{
    public class Customer : IEntity<long>, ICloneableType
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
        }

        public long Id { get; private set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
        public string EMail { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
