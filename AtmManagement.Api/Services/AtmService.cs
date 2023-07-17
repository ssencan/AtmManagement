using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;
using AtmManagement.Api.Validators;

namespace AtmManagement.Api.Services

{
    public class AtmService: IAtmService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AtmService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AtmDto> Add(AtmDto atmDto)
        {
           
            await _unitOfWork.Atms.AddAtm(atmDto);
            await _unitOfWork.SaveChangesAsync();
            return atmDto;
        }

    }
}
