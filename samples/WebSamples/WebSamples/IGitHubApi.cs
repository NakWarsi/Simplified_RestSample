using System.Threading.Tasks;
using Refit;

namespace WebSamples.Controllers
{
    internal interface IGitHubApi
    {
        [Get("/users/{user}")]
        Task<User> GetUser(string user);
    }
}