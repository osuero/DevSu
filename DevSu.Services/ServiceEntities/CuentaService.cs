using AutoMapper;
using DevSu.Core.Interfaces;
using DevSu.Core.Models;
using DevSu.Services.Dto;
using DevSu.Services.Interfaces;
using DevSu.Services.ServiceHandlers;

namespace DevSu.Services.ServiceEntities
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IValidacionCuentaService _accountValidationsRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public CuentaService(IValidacionCuentaService accountValidationsRepository, ICuentaRepository cuentaRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            _cuentaRepository = cuentaRepository;
            _accountValidationsRepository = accountValidationsRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CuentaCreateDto dto)
        {
            bool clientNameExists = await _accountValidationsRepository.DoesClientNameExist(dto.ClienteNombre);
            if (!clientNameExists)
            {
                throw new AppExceptionHandler("El cliente no existe.");
            }

            bool accountExists = await _accountValidationsRepository.DoesAccountExist(dto.NumeroCuenta);
            if (accountExists)
            {
                throw new AppExceptionHandler("Este numero de cuenta ya existe.");
            }

            var cliente = await _clienteRepository.GetWhere(x => x.Nombres == dto.ClienteNombre);

            if (cliente == null)
            {
                throw new AppExceptionHandler("El cliente no pudo ser encontrado.");
            }

            var cuenta = _mapper.Map<Cuenta>(dto);

            cuenta.ClienteId = cliente.Select(x=>x.Id).FirstOrDefault();

            await _cuentaRepository.Create(cuenta);
        }


        public async Task DeleteAsync(int id)
        {
            await _cuentaRepository.Delete(id);
        }

        public async Task<IEnumerable<CuentaDto>> GetAllAsync()
        {
            var cuenta = await _cuentaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CuentaDto>>(cuenta);
        }

        public async Task<CuentaDto> GetByIdAsync(int id)
        {
            var entity = await _cuentaRepository.GetByIdAsync(id);
            return _mapper.Map<CuentaDto>(entity);
        }

        public async Task UpdateAsync(CuentaDto dto)
        {
            bool clientNameExists = await _accountValidationsRepository.DoesClientNameExist(dto.ClienteNombre);
            if (!clientNameExists)
            {
                throw new AppExceptionHandler("El cliente no existe.");
            }

            var existingAccount = await _cuentaRepository.GetByIdAsync(dto.Id);
            if (existingAccount.NumeroCuenta != dto.NumeroCuenta)
            {
                bool accountExists = await _accountValidationsRepository.DoesAccountExist(dto.NumeroCuenta);
                if (accountExists)
                {
                    throw new AppExceptionHandler("El numero de cuenta ya existe.");
                }
            }

            var cliente = await _clienteRepository.GetWhere(x => x.Nombres == dto.ClienteNombre);

            if (cliente == null)
            {
                throw new AppExceptionHandler("El cliente no existe.");
            }

            var cuenta = _mapper.Map<Cuenta>(dto);
            cuenta.ClienteId = cliente.Select(x => x.Id).FirstOrDefault();
            await _cuentaRepository.Update(cuenta);
        }
    }
}
