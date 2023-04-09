using BackgroundtasksForEcommerceTutorial.Models;
using BackgroundtasksForEcommerceTutorial.Serves;

namespace BackgroundtasksForEcommerceTutorial.BackgroundTasks
{
    public class SendDiscountCodeTask
    {

        private readonly ILogger<SendDiscountCodeTask> _logger;
        private readonly IDiscountCode _discountCode;

        public SendDiscountCodeTask(ILogger<SendDiscountCodeTask> logger, IDiscountCode discountCode)
        {
            _logger = logger;
            _discountCode = discountCode;
        }

        public async Task DoSomethingAsync()
        {
            //new user created
            User user = new();

            //call servevs to run 
            var task = Task.Run(() => _discountCode.SendToUser(user.Email));
            task.Wait();


        }
    }
}
