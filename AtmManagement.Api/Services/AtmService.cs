using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;

namespace AtmManagement.Api.Services
{
    public class AtmService : IAtmService
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

        public async Task UpdateAtm(AtmDto atmDto)
        {
            var atm = await _unitOfWork.Atms.GetAtmById(atmDto.Id);
            if (atm == null)
                throw new Exception("ATM not found");
            await _unitOfWork.Atms.UpdateAtm(atmDto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<AtmDto> Add(AtmDto atmDto)
        {
            await _unitOfWork.Atms.AddAtm(atmDto);
            await _unitOfWork.SaveChangesAsync();
            return atmDto;
        }

        public async Task DeleteAtm(int id)
        {
            var atm = await _unitOfWork.Atms.GetAtmById(id);
            if (atm == null)
                throw new Exception("ATM not found");
            await _unitOfWork.Atms.DeleteAtm(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
