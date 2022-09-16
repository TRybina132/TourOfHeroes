using Service.ServicesAbstractions;

namespace Service.Services
{
    internal class LogService : ILogService
    {
        public async Task LogAsync(string message)
        {
            try
            {
                using var writer = new StreamWriter(@"D:\stuff\tourOfHeroesLogs.txt", true);
                await writer.WriteLineAsync(message);
            }
            catch(Exception ex)
            {
                return;
            }
        }
    }
}
