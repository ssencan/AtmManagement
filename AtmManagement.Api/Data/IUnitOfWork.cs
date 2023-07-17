using AtmManagement.Api.Data.Repositories;
using AtmManagement.Api.Entities;
using System.Threading.Tasks;

namespace AtmManagement.Api.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<City> Cities { get; }
        IAtmRepository Atms { get; }
        IDistrictRepository Districts { get; }
        // Other repositories...

        Task SaveChangesAsync();
    }

}
