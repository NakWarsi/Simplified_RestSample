using System.Threading.Tasks;
using Refit;
using WebSamples.Models;

namespace WebSamples.Controllers
{
    internal interface IGitHubApi
    {
        [Get("/users/{user}")]
        Task<UserDetails> GetUser(string user);

        [Get("/users/NakWarsi")]
        Task<UserDetails> GiTHubUserDetails();
    }
}