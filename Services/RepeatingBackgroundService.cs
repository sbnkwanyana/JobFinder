namespace JobFinder.Services;

public class RepeatingBackgroundService : BackgroundService
{
    private readonly ILogger<RepeatingBackgroundService> _logger;
    //private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(1000));

    public RepeatingBackgroundService(ILogger<RepeatingBackgroundService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (/* await _timer.WaitForNextTickAsync(stoppingToken) &&  */!stoppingToken.IsCancellationRequested)
        {
            //.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}