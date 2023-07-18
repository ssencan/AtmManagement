﻿using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

namespace AtmManagement.Api.Services
{
    public class AtmService: IAtmService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtmService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AtmDto>> GetAllAtm()
        {
            var atms = await _unitOfWork.Atms.GetAllAtm();
            return atms;
        }

        public async Task<AtmDto> GetAtmById(int id)
        {
            var atm = await _unitOfWork.Atms.GetAtmById(id);
            return atm;
        }

        public async Task<Atm> UpdateAtm(AtmDto atmDto)
        {
            var atm = await _unitOfWork.Atms.GetByIdAsync(atmDto.Id);
            if (atm == null)
                return null;
            atm.AtmName = atmDto.AtmName;
            atm.Latitude = atmDto.Latitude;
            atm.DistrictID = atmDto.DistrictID;
            atm.Longitude = atmDto.Longitude;
            atm.CityID = atmDto.CityID;
            atm.IsActive = atmDto.IsActive;
            await _unitOfWork.SaveChangesAsync();
            return atm;
        }

        public async Task<AtmDto> AddAtm(AtmDto atmDto)
        {
            var atm = new Atm
            {
                AtmName = atmDto.AtmName,
                Latitude = atmDto.Latitude,
                Longitude = atmDto.Longitude,
                IsActive = atmDto.IsActive,
                CityID = atmDto.CityID,
                DistrictID = atmDto.DistrictID
            };
            await _unitOfWork.Atms.AddAsync(atm);
            await _unitOfWork.SaveChangesAsync();
            return atmDto;
        }

        public async Task<Atm> DeleteAtm(int id)
        {
            var atm = await _unitOfWork.Atms.GetByIdAsync(id);
            if (atm == null)
                return null;
            atm.IsActive = false;
            await _unitOfWork.SaveChangesAsync();
            return atm;
        }

    }
}
