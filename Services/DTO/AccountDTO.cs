using Domain.Enum;

namespace Services.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
    }
}
