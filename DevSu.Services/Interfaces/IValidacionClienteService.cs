namespace DevSu.Services.Interfaces
{
    public interface IValidacionClienteService
    {
        Task<bool> DoesClientExist(string names, string phoneNumber);
    }
}
