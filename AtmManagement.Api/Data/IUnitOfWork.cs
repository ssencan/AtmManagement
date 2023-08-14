using AtmManagement.Api.Data.Repositories;

namespace AtmManagement.Api.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository Cities { get; }
        IAtmRepository Atms { get; }
        IDistrictRepository Districts { get; }
       
        Task SaveChangesAsync();
    }

}
