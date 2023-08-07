using DevSu.Core.Interfaces;
using DevSu.Services.Interfaces;

namespace DevSu.Services.ServiceHandlers
{
    public class ValidacionClienteService : IValidacionClienteService
    {
        public IValidacionClienteRepository _validationRepository;
        public ValidacionClienteService(IValidacionClienteRepository validationRepository)
        {
            _validationRepository = validationRepository;
        }

        public async Task<bool> DoesClientExist(string names, string phoneNumber)
        {
           return await _validationRepository.DoesClientExist(names, phoneNumber);
        }
    }
}
