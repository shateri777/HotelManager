using Autofac;
using HotellApp_Databasteknik_2.Data;
namespace HotellApp_Databasteknik_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = AutofacConfig.ConfigureContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<Application>();
                app.Run();
            }
        }
    }
}
