using CK.Owin.Core.Middleware;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using CK.Owin.Common.Constants;

namespace CK.Owin
{
    public class Startup 
    {
        public static void Configuration(IAppBuilder app)
        {
            //app.Use(async (ctx, next) =>
            //{
            //    Debug.WriteLine("Incoming Request..." + ctx.Request.Path);
            //    Debug.WriteLine("Outgoing Request..." + ctx.Request.Path);
            //    await next();
            //});

            //app.Use<DebugMiddleware>();

            app.UseDebugMiddleware();
            //app.Use(async(ctx, next) =>
            //{
            //    await ctx.Response.WriteAsync("Hello world !");
            //});

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = ApplicationConstant.AUTHENTICATION_TYPE,
                LoginPath=new Microsoft.Owin.PathString("/Login/Index")

            });
        }
    }
}