using CK.Owin.Core.Middleware;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

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
            app.Use(async(ctx, next) =>
            {
                await ctx.Response.WriteAsync("Hello world !");
            });
        }
    }
}