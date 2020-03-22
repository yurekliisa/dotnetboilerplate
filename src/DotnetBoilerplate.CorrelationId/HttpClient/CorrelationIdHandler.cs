﻿using System.Net.Http;
using DotnetBoilerplate.CorrelationId.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetBoilerplate.CorrelationId.HttpClient
{
    /// <summary>
    /// A <see cref="DelegatingHandler"/> which adds the correlation ID header from the <see cref="CorrelationContext"/> onto outgoing HTTP requests.
    /// </summary>
    internal sealed class CorrelationIdHandler : DelegatingHandler
    {
        private readonly ICorrelationContextAccessor _correlationContextAccessor;
        
        public CorrelationIdHandler(ICorrelationContextAccessor correlationContextAccessor) => _correlationContextAccessor = correlationContextAccessor;

        /// <inheritdoc cref="DelegatingHandler"/>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains(_correlationContextAccessor.CorrelationContext.Header))
            {
                request.Headers.Add(_correlationContextAccessor.CorrelationContext.Header, _correlationContextAccessor.CorrelationContext.CorrelationId);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
