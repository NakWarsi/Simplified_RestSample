using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using WebSamples.Models;

namespace WebSamples.Controllers
{
    internal interface IGitHubApi
    {
        [Get("/users/{user}")]
        Task<UserDetails> GetUser([AliasAs("user")] string user);

        [Get("/users/NakWarsi")]
        Task<UserDetails> GiTHubUserDetails();

        [Get("/users?since={id}")]
        Task<List<Account>> ListOfAccounts([AliasAs("id")] int userid);
    }
}
