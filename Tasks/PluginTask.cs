using SmartStore.Services;
using SmartStore.Services.Tasks;
//using SmartStore.WebHooks.Services;

namespace SmartStore.WebHooks
{
    public class MyFirstTask : ITask
    {
        private readonly ICommonServices _services;


        public MyFirstTask(
            ICommonServices services)
        {
            _services = services;

        }

        public void Execute(TaskExecutionContext context)
        {
            // Do something
        }
    }
}