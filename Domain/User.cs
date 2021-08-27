using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<AccountTransaction> AccountTransactions { get; set; }
        public Account Account { get; set; }
    }
}
