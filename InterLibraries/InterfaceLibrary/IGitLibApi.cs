using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary.Models;
using Refit;

namespace InterfaceLibrary
{
    public interface IGitLibApi
    {
        [Get("/users/{user}")]
        Task<UserDetails> GetUser([AliasAs("user")] string user);

        [Get("/users/NakWarsi")]
        Task<UserDetails> GiTHubUserDetails();

        [Get("/users?since={id}")]
        Task<List<Account>> ListOfAccounts([AliasAs("id")] int userid);
    }
}
