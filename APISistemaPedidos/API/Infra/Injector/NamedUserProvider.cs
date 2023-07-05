using Microsoft.AspNetCore.SignalR;

namespace API.Infra.Injector
{
    public class NamedUserProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity?.Name;
        }
    }
}
