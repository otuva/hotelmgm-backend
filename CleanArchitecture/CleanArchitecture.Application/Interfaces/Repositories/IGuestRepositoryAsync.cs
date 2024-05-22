using CleanArchitecture.Core.Entities;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IGuestRepositoryAsync : IGenericRepositoryAsync<Guest>
    {
        Task<bool> IsUniqueEmailAsync(string email);
    }
}
