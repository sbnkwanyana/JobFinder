namespace JobFinder.Services;

public class RepeatingBackgroundService : BackgroundService
{
    private readonly ILogger<RepeatingBackgroundService> _logger;
    //private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(1000));
    private readonly HttpClient _httpClient;

    public RepeatingBackgroundService(ILogger<RepeatingBackgroundService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (/* await _timer.WaitForNextTickAsync(stoppingToken) &&  */!stoppingToken.IsCancellationRequested)
        {
            //.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            var response = await _httpClient.GetFromJsonAsync<Joke>("https://api.chucknorris.io/jokes/random");
            _logger.LogInformation("Joke: {reponse}", response?.Value);
            await Task.Delay(10000, stoppingToken);
        }
    }
}