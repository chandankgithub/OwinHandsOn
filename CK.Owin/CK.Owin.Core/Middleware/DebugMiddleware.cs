using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using AppFunc = System.Func<
        System.Collections.Generic.IDictionary<string, object>,
        System.Threading.Tasks.Task
    >;

namespace CK.Owin.Core.Middleware
{
    public class DebugMiddleware
    {
        private readonly AppFunc _next;
        private readonly DebugMiddlewareOptions _options;

        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options = null)
        {
            this._next = next;
            this._options = options;

            if(this._options.OnIncomingRequest == null)
            {
                this._options.OnIncomingRequest = (ctx) =>
                {
                    Debug.WriteLine("Incoming Request..." + ctx.Request.Path);
                };
            }
            if (this._options.OnOutgoingRequest == null)
            {
                this._options.OnOutgoingRequest = (ctx) =>
                {
                    Debug.WriteLine("Outgoing Request..." + ctx.Request.Path);
                };
            }
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);
            this._options.OnIncomingRequest(ctx);
            await this._next(environment);
            this._options.OnOutgoingRequest(ctx);
        }
    }
}
