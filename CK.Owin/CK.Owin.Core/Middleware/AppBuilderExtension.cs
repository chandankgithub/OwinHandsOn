using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CK.Owin.Core.Middleware
{
    public static class AppBuilderExtension
    {
        public static void UseDebugMiddleware(this IAppBuilder app)
        {
            //app.Use<DebugMiddleware>(new DebugMiddlewareOptions());


            app.Use<DebugMiddleware>(new DebugMiddlewareOptions
            {
                OnIncomingRequest = (ctx) =>
                {
                    //Debug.WriteLine("Incoming Request..." + ctx.Request.Path);
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["stopwatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["stopwatch"];
                    watch.Stop();
                    Debug.WriteLine("Total elapsed time is " + watch.ElapsedMilliseconds + " ms");
                }
            });

        }
    }
}
