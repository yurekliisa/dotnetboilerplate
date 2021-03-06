using Microsoft.AspNetCore.Http;

namespace DotnetBoilerplate.Helpers
{
    public interface IWebHelper
    {
        bool IsSecureConnection { get; }
        string UrlReferrer { get; }
        string CurrentIpAddress { get; }
        string ServerIpAddress { get; }
        string UserAgent { get; }
        string GetThisPageUrl(bool includeQueryString, bool? useSsl = null, bool lowercaseUrl = false);
        string GetHost(bool useSsl);
        string GetLocation(bool? useSsl = null);
        string GetRawUrl(HttpRequest request);
    }
}