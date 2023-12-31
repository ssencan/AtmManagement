﻿using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

namespace AtmManagement.Api.Data.Repositories
{
    public interface IAtmRepository:IRepository<Atm>
    {
        Task<IEnumerable<AtmDto>> GetAllAtm();
        Task<AtmDto> GetAtmById(int id);

    }
}
