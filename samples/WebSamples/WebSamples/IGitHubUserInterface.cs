using System.Threading.Tasks;
using Refit;
using WebSamples.Models;

namespace WebSamples
{
    interface IGitHubUserInterface
    {
        [Get("/users/NakWarsi")]
        Task<UserDetails> GiTHubUserDetails();
    }
}
