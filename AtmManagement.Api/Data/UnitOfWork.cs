using AtmManagement.Api.Data.Repositories;
using AtmManagement.Api.Entities;

using System.Threading.Tasks;

namespace AtmManagement.Api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AtmDbContext _context;
        private CityRepository _cityRepository;
        private DistrictRepository _districtRepository;
        private IAtmRepository _atmRepository;

        public UnitOfWork(AtmDbContext context)
        {
            _context = context;
        }

        public IRepository<City> Cities
        {
            get
            {
                return _cityRepository ??= new CityRepository(_context);
            }
        }



        public IRepository<District> Districts
        {
            get
            {
                return _districtRepository ??= new DistrictRepository(_context);
            }
        }

        public IAtmRepository Atms
        {
            get
            {
                return _atmRepository ??= new AtmRepository(_context);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
