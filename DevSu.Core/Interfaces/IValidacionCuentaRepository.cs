namespace DevSu.Core.Interfaces
{
    public interface IValidacionCuentaRepository
    {
       Task<bool> DoesClientNameExist(string clientName);
       Task<bool> DoesAccountExist(int accountNumber);
    }
}
