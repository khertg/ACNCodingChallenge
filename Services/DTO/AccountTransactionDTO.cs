using System;

namespace Services.DTO
{
    public class AccountTransactionDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Desc { get; set; }
    }
}
