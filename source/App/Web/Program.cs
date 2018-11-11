using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Solution.App.Web
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build().Run();
        }
    }
}
