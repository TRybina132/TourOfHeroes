namespace Service.ServicesAbstractions
{
    public interface ILogService
    {
        Task LogAsync(string message);
    }
}
