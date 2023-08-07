namespace DevSu.Services.ServiceHandlers
{
    public class AppExceptionHandler : Exception
    {
        public AppExceptionHandler(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }

        // TODO List:
        // 1. si en algun momento ustedes desan hacer log en la base de datos de los errores que salgan es facil.
        // 2. crear una entidad con los siguientes campos:
        //   - Id
        //   - Date and Time
        //   - Method Name
        //   - Endpoint Name
        //   - Message
        //   - InnerException
        //   - InputData: aqui se campuran los datos indistintamente el dto y de esta forma es mas facil hacer debug.
    }
}
