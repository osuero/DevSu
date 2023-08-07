using DevSu.Core.Interfaces;
using DevSu.Services.Interfaces;

namespace DevSu.Services.ServiceHandlers
{
    public class ValidacionCuentaService: IValidacionCuentaService
    {

        public IValidacionCuentaRepository _validationRepository;
        public ValidacionCuentaService(IValidacionCuentaRepository validationRepository) 
        {
            _validationRepository = validationRepository;
        }

        public async Task<bool> DoesAccountExist(int accountNumber)
        {
           return await _validationRepository.DoesAccountExist(accountNumber);
        }

        public async Task<bool> DoesClientNameExist(string clientName)
        {
            return await _validationRepository.DoesClientNameExist(clientName);
        }
    }
}
