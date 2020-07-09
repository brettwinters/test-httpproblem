using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BlazorApp1.Pages;
using Fluxor;

namespace BlazorApp1.Shared
{
    public class HttpProcessingDelegatingHandler : DelegatingHandler
    {
        private readonly IDispatcher _dispatcher;

        public HttpProcessingDelegatingHandler(
             IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;

        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Debug.WriteLine("HttpProcessingDelegatingHandler Called");

            _dispatcher.Dispatch(new IsFetchingAction());

            await Task.Delay(3000);

            var response = await base.SendAsync(request, cancellationToken);

            _dispatcher.Dispatch(new HasFetchedAction());

            return response;
        }
    }
}
