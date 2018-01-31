using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CK.Owin.Core.Middleware
{
    public class DebugMiddlewareOptions : IDebugMiddlewareOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set ; }
        public Action<IOwinContext> OnOutgoingRequest { get; set; }
    }

    public interface IDebugMiddlewareOptions
    {
        Action<IOwinContext> OnIncomingRequest { get; set; }
        Action<IOwinContext> OnOutgoingRequest { get; set; }
    }
}
