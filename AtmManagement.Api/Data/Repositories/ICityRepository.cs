﻿using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

namespace AtmManagement.Api.Data.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<CityDto>> GetAllCity();
        Task<CityDto> GetCityById(int id);
    }
}
