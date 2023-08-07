namespace DevSu.Services.Interfaces
{
    public interface IValidacionCuentaService
    {
        Task<bool> DoesClientNameExist(string clientName);
        Task<bool> DoesAccountExist(int accountNumber);
    }
}
