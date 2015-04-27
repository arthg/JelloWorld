using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JelloWorld.Startup))]

namespace JelloWorld
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseWelcomePage("/");
            app.UseErrorPage();
            app.Run(context =>
                    {
                        if (context.Request.Path.ToString() == "/fail")
                        {
                            throw new Exception("You requested the wrong URL :)");
                        }

                        context.Response.ContentType = "text/plain";
                        return context.Response.WriteAsync("Jello Katana on IIS World!");
                    });
        }
    }
}
