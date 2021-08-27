using Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class AccountTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public TransactionStatus Status { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Desc { get; set; }

        public User User { get; set; }
        public Account Account { get; set; }
    }
}
