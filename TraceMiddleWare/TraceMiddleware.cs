using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TraceMiddleWare
{
    public class TraceMiddleWare
    {
        private readonly RequestDelegate _next;
        public TraceMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            int post = context.Connection.LocalPort;  

            var parentId = Activity.Current.GetBaggageItem("HttpReports.Trace.Id");

            if (string.IsNullOrEmpty(parentId))
            {
                Activity activity = new Activity("HttpReports.Trace.Activity"); 
                activity.Start();
                activity.AddBaggage("HttpReports.Trace.Id", activity.Id);
            }
            else
            {
                Activity activity = new Activity("HttpReports.Trace.Activity");
                activity.SetParentId(parentId); 
                activity.Start();
                activity.AddBaggage("HttpReports.Trace.Id", activity.Id);
            }

            await _next(context);
        }

    }
}
