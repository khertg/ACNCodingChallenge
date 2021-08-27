using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<AccountTransaction> AccountTransactions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
