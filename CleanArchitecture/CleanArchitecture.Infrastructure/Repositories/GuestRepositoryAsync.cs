using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class GuestRepositoryAsync : GenericRepositoryAsync<Guest>, IGuestRepositoryAsync
    {
        private readonly DbSet<Guest> _Guests;

        public GuestRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _Guests = dbContext.Set<Guest>();
        }

        public Task<bool> IsUniqueEmailAsync(string Email)
        {
            return _Guests
                .AllAsync(p => p.Email != Email);
        }
    }
}
