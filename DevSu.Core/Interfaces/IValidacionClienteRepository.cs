namespace DevSu.Core.Interfaces
{
    public interface IValidacionClienteRepository
    {
        Task<bool> DoesClientExist(string names, string phoneNumber);
    }
}
