namespace BackgroundtasksForEcommerceTutorial.Serves
{
    public interface IDiscountCode
    {

        Task SendToUser(string Email);
    }


    public class DiscountCode : IDiscountCode
    {
        private readonly ILogger<DiscountCode> _logger;

        public DiscountCode(ILogger<DiscountCode> logger)
        {
            _logger = logger;
        }

        public async Task SendToUser(string Email)
        {
           _logger.LogInformation($"The discount code has been sent to {Email} successfully");
        }
    }

}
